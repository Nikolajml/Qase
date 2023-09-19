using Bogus;
using Core.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Steps.Steps;
using UI.Models;
using NUnit.Framework.Interfaces;

namespace Tests.UI
{
    public class SuiteCreateTest : CommonBaseTest
    {
        protected ILogger logger;
        public ProjectTPStepsPage _projectTPStepsPage;
        public SuiteStep _suiteStep;
        public NavigationSteps NavigationSteps;

        public string? BaseUrl;
        protected IWebDriver Driver;
        public Faker Faker = new Faker();

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            BaseUrl = config.AppSettings.URL;
            Driver = new Browser().Driver;

            logger = LogManager.GetCurrentClassLogger();

            _suiteStep = new SuiteStep(logger, Driver);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.IsPageOpened();
        }

        [Test]
        [Description("Successful UI test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName(Faker.Name.FullName())
                .SetSuiteDescription(Faker.Vehicle.Model())
                .SetSuitePreconditions(Faker.Vehicle.Vin())
                .Build();

            _projectTPStepsPage.NavigateToCreateSuite();
            _suiteStep.CreateSuit(suite);

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
