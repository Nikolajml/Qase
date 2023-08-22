using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using UI.Pages;
using Core.Utilities.Configuration;
using Steps.UISteps;
using Core.Core;
using Core.Utilities;

namespace Tests.UI
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected IWebDriver Driver;
        private AllureLifecycle _allure;
        protected EntityHandler entityHandler = new EntityHandler();

        public LoginPage LoginPage { get; set; }
        public ProjectsPage ProjectsPage { get; set; }
        public PlanTPPage PlanTPPage { get; set; }
        public DefectsTPPage DefectTPPage { get; set; }
        public ProjectTPPage ProjectTPPage { get; set; }

        public PlanStepsPage PlanStepsPage { get; set; }
        public DefectStepsPage DefectStepsPage { get; set; }
        public SuiteStepsPage SuiteStepsPage { get; set; }
        public CaseStepsPage CaseStepsPage { get; set; }


        [OneTimeSetUp] // Impliment OneTimeSetup
        public void Setup() // Все объекты пэджей должны инициализироваться вне теста
        {
            Driver = new Browser().Driver;
            _allure = AllureLifecycle.Instance;
            LoginPage = new LoginPage(Driver);
            ProjectsPage = new ProjectsPage(Driver);

            LoginPage.OpenPage();
            LoginPage.TryToLogin(Configurator.Admin);
            ProjectsPage.IsPageOpened();

            PlanTPPage = new PlanTPPage(Driver);
            PlanStepsPage = new PlanStepsPage(Driver);

            DefectTPPage = new DefectsTPPage(Driver);
            DefectStepsPage = new DefectStepsPage(Driver);

            ProjectTPPage = new ProjectTPPage(Driver);
            SuiteStepsPage = new SuiteStepsPage(Driver);
            CaseStepsPage = new CaseStepsPage(Driver);
        }

        [OneTimeTearDown] // Impliment OneTearDown
        public void TearDown()
        {
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
