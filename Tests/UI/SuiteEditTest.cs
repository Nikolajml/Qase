using Bogus;
using Core.Client;
using Core.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Steps.Steps;
using UI.Models;
using NUnit.Framework.Interfaces;

namespace Tests.UI
{
    public class SuiteEditTest : CommonBaseTest
    {
        protected ILogger logger;
        protected IWebDriver Driver;
        protected ApiClient _apiClient;

        public ProjectTPStepsPage _projectTPStepsPage;
        public SuiteStep _suiteStep;
        public NavigationSteps NavigationSteps;

        public string? BaseUrl;
        
        public Faker Faker = new Faker();


        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            logger = LogManager.GetCurrentClassLogger();

            _suiteStep = new SuiteStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin!);

            if (NavigationSteps.IsPageOpened() == false)
            {
                Assert.Inconclusive("The Projects Page didn't open");
            }
        }

        [SetUp]
        public void SetUp()
        {
            Suite suite = new SuiteBuilder()
               .SetSuiteName(Faker.Name.FullName())
               .SetSuiteCode("TP")
               .Build();

            _suiteStep.CreateTestSuite_API(suite);
        }

        [Test]
        [Description("Successful UI test to edit a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Edited Suite")
                .Build();

            _projectTPStepsPage.NavigateToEditSuite();
            _suiteStep.EditSuit_UI(suite);

            Assert.That(_projectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _suiteStep.DeleteSuite_UI();

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
