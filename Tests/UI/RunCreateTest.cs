using Bogus;
using Core.Client;
using Core.Core;
using NUnit.Framework.Interfaces;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Tests.UI
{
    public class RunCreateTest : CommonBaseTest
    {      
        protected ILogger logger;
        protected IWebDriver Driver;
                
        Case Case { get; set; }
        Project project { get; set; }
        
        public CaseStep _caseStep;
        public RunStep _runStep;
        public NavigationSteps NavigationSteps;
        public ProjectTPStepsPage ProjectTPStepsPage;

        public string? BaseUrl;

        public Faker Faker = new Faker();

        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {        
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            _apiClient = new ApiClient(config.Bearer!);
            logger = LogManager.GetCurrentClassLogger();

            _projectStep = new ProjectStep(logger, _apiClient);
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _runStep = new RunStep(logger, Driver, _apiClient);
            NavigationSteps = new NavigationSteps(logger, Driver);
            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            // WaitService = new WaitService(Driver);

            project = new Project()
            {
                Code = "RUN",
                Title = Faker.Company.CompanyName(),
                Access = "all"
            };

            var createdProject = _projectStep.CreateTestProject_API(project);

            if (createdProject.Status == false)
            {
                Assert.Inconclusive("The Project for RunUITest wasn't created");
            }

            ProjectsForDelete.Add(project);

            Case = new Case()
            {
                Code = project.Code,
                Title = Faker.Name.JobTitle()
            };

            var createdCase = _caseStep.CreateTestCase_API(Case);

            if (createdCase.Status == false)
            {
                Assert.Inconclusive("The Case for RunUITest wasn't created");
            }

            Case.Id = createdCase.Result.id.ToString();
            int CaseIdForRun = int.Parse(Case.Id);
            logger.Debug($"Case Id: {Case.Id}");
            Console.WriteLine($"Case Id: {CaseIdForRun}");               

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin!);

            if (NavigationSteps.IsPageOpened() == false)
            {
                Assert.Inconclusive("The Project Page wasn't opened");
            }
        }

        [Test]
        [Description("Creation of test run through UI test")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateTestRunTest()
        {     
            Run run = new RunBuilder()
                .SetRunDescription(Faker.Name.FullName())
                .Build();

            NavigationSteps.NavigateToProjectForUITest_UI();
            ProjectTPStepsPage.NavigateToRunPage();
            _runStep.CreateTestRun(run);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(_runStep.IsRunDescriptionVisiable(), "Created Test Run Description is not visiable");
                Assert.That(_runStep.GetRunDescriptionForAssert(), Is.EqualTo(run.Description), "Created Test Run description didn't match");
            });            
        }       // Implicite wait Explicite wait


        [OneTimeTearDown]
        public void TearDown()
        {     
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}