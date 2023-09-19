using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using Core.Core;
using OpenQA.Selenium;
using NLog;
using Bogus;
using NUnit.Framework.Interfaces;
using Core.Client;
using Core.Utilities.Configuration;

namespace Tests.UI
{
    public class CaseCreateTest : CommonBaseTest
    {
        protected ILogger logger;
        Case Case;
        public ProjectTPStepsPage ProjectTPStepsPage;
        public CaseStep _caseStep;
        public NavigationSteps NavigationSteps;

        public string? BaseUrl;
        protected IWebDriver Driver;
        public Faker Faker = new Faker();

        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            _apiClient = new ApiClient(new Configurator().Bearer);
            logger = LogManager.GetCurrentClassLogger();

            _caseStep = new CaseStep(logger, Driver, _apiClient);
            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.IsPageOpened();
        }

        [Test]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateCaseTest()
        {
            Case = new CaseBuilder()
                .SetCaseTitle(Faker.Name.FullName())
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();            
            Assert.IsTrue(_caseStep.IsPageOpened(), "The CasePage wasn't opened");

            _caseStep.CreateCase(Case);
            Assert.That(ProjectTPStepsPage.CreatedCaseTitleForAssert(), Is.EqualTo(Case.Title), "Title created Case desn't much to expected Case Title");
        }

        [TearDown]
        public void EditTearDown()
        {
            _caseStep.DeleteTestCaseByName(Case.Title, "TP");


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
