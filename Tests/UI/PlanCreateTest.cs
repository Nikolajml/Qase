using Bogus;
using Core.Client;
using Core.Core;
using Core.Utilities.Configuration;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Steps.Steps;
using UI.Models;
using NUnit.Framework.Interfaces;

namespace Tests.UI
{
    public class PlanCreateTest : CommonBaseTest
    {
        protected ILogger logger;
        Plan plan;
        Case Case;

        public ProjectTPStepsPage ProjectTPStepsPage;
        public NavigationSteps NavigationSteps;
        public PlanStep _planStep;
        public CaseStep _caseStep;

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

            ProjectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _planStep = new PlanStep(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.IsPageOpened();
        }

        [SetUp]
        public void SetUp()
        {
            Case = new CaseBuilder()
                .SetCaseTitle(Faker.Name.FullName())
                .Build();

            ProjectTPStepsPage.NavigateToCreateCase();
            Assert.IsTrue(_caseStep.IsPageOpened(), "The CasePage wasn't opened");

            _caseStep.CreateCase(Case);
            Thread.Sleep(1000);
        }

        [Test]
        [Description("Successful UI test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreatePlanTest()
        {
            plan = new PlanBuilder()
                .SetPlanTitle(Faker.Name.FullName())
                .SetPlanDescription(Faker.Vehicle.Model())
                .Build();

            _planStep.NavigateToPlanPage();
            _planStep.CreatePlan(plan);
                        

            Assert.That(_planStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title), "Plan title doesn't match expected result");

            _planStep.NavigateToCreatedPlanForSecondAssert();

            Assert.Multiple(() =>
            {
                Assert.That(_planStep.CreatedPlanTitleForSecondAssert(), Is.EqualTo(plan.Title), "Plan title doesn't match expected result");
                Assert.That(_planStep.CreatedPlanDescriptionForSecondAssert, Is.EqualTo(plan.Description), "Plan description doesn't match expected result");
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _planStep.NavigateToPlanPage();
            _planStep.DeletePlan_UI();

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
