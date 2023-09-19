using Bogus;
using Core.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Steps.Steps;
using UI.Models;
using NUnit.Framework.Interfaces;
using Core.Client;
using Core.Utilities.Configuration;

namespace Tests.UI
{
    public class CaseEditTest : CommonBaseTest
    {
        protected ILogger logger;
        Case Case;
        Case CaseForEdit;
        public CaseStep _caseStep;
        public ProjectTPStepsPage _projectTPStepsPage;
        public NavigationSteps NavigationSteps;

        public string? BaseUrl;
        protected IWebDriver Driver;
        public Faker Faker = new Faker();

        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            _apiClient = new ApiClient(new Configurator().Bearer);
            logger = LogManager.GetCurrentClassLogger();

            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.IsPageOpened();
        }

        [SetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "TP",
                Title = Faker.Name.FullName()
            };

            _caseStep.CreateTestCase_API(Case);
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            CaseForEdit = new CaseBuilder()
               .SetCaseTitle(Faker.Name.FullName())
               .Build();

            _projectTPStepsPage.NavigateToEditCase();
            _caseStep.EditCase(CaseForEdit);

            Assert.That(_projectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(CaseForEdit.Title), "Edited Case Title doesn't mutch to expected Case Title");
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, Case.Code);
            _caseStep.DeleteTestCaseByName(CaseForEdit.Title, "TP");

            
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
