using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using Core.Core;
using NLog;
using Bogus;
using OpenQA.Selenium;
using Core.Client;
using Core.Utilities.Configuration;

using NUnit.Framework.Interfaces;

namespace Tests.MixTests
{
    public class CaseMixTest : CommonBaseTest
    {        
        Case Case { get; set; }
        Project project { get; set; }

        public List<Case> CasesForDelete = new List<Case>();
        public List<Project> ProjectsForDelete = new List<Project>();

        public ProjectStep _projectStep;
        public CaseStep _caseStep;
        public ProjectTPStepsPage _projectTPStepsPage;
        public NavigationSteps NavigationSteps;

        public string? BaseUrl;
        protected ILogger logger;
        protected IWebDriver Driver;
        public Faker Faker = new Faker();

        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void OneTimeTtestSetUp()
        {
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            _apiClient = new ApiClient(new Configurator().Bearer);
            logger = LogManager.GetCurrentClassLogger();

            _projectStep = new ProjectStep(logger, _apiClient);
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            project = new Project()
            {
                Code = "MIX",
                Title = "MixCasesTest",
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for CaseMixTests didn't create");
            }

            ProjectsForDelete.Add(project);


            Case = new CaseBuilder()
               .SetCaseTitle("MIX TEST CASE Test")
               .SetCode(project.Code)
               .Build();

            var createdTestCase = _caseStep.CreateTestCase_API(Case);

            Case.Id = createdTestCase.Result.id.ToString();
            logger.Info("Created Case Id: " + createdTestCase.Result.id.ToString());
                        
            CasesForDelete.Add(Case);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);                       

            if (NavigationSteps.IsPageOpened() == false)
            {
                Assert.Inconclusive("The Projects Page didn't open");
            }
        }


        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseMixTest()
        {
            Case.Title = "Edited Case UI";
                        
            NavigationSteps.NavigateToProjectForEditCase_MIX();
            _projectTPStepsPage.NavigateToEditCase_MIX();
            _caseStep.EditCase(Case);

            Assert.That(_projectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "Edited Case Title didn't match");
        }


        [OneTimeTearDown]
        public void TearDown()
        {      
            foreach (var projectForDelete in ProjectsForDelete)
            {
                _projectStep.DeleteTestProject_API(projectForDelete);
            }

            // Проверка, что тест упал
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // Создание скриншота
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                // Прикрепление сриншота
                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
