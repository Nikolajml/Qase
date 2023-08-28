using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using UI.Pages;
using Core.Utilities.Configuration;
using Steps.UISteps;
using Core.Core;
using Core.Utilities;
using Bogus;

namespace Tests.UI
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected IWebDriver Driver;
        private AllureLifecycle _allure;
        protected CleanUpHandler cleanUpHandler = new CleanUpHandler();
        public Faker Faker = new Faker();

        public LoginPage LoginPage;
        public ProjectsPage ProjectsPage;
        //public PlanTPPage PlanTPPage;
        //public DefectsTPPage DefectTPPage;
        //public ProjectTPPage ProjectTPPage; // Сделать поля в API Service

        public PlanStepsPage PlanStepsPage; // Должны быть только Steps
        public DefectStepsPage DefectStepsPage;
        public SuiteStepsPage SuiteStepsPage;
        public CaseStepsPage CaseStepsPage;
        public ProjectTPStepsPage ProjectTPStepsPage;


        [OneTimeSetUp] // Impliment OneTimeSetup
        public void Setup() // Все объекты пэджей должны инициализироваться вне теста
        {
            Driver = new Browser().Driver;
            _allure = AllureLifecycle.Instance;
            LoginPage = new LoginPage(Driver);
            ProjectsPage = new ProjectsPage(Driver);

            LoginPage.OpenPage();       // убрать страницы из тестов - отсавить steps
            LoginPage.TryToLogin(Configurator.Admin);
            ProjectsPage.IsPageOpened();

           //PlanTPPage = new PlanTPPage(Driver);
            PlanStepsPage = new PlanStepsPage(Driver);

            //DefectTPPage = new DefectsTPPage(Driver);
            DefectStepsPage = new DefectStepsPage(Driver);

            //ProjectTPPage = new ProjectTPPage(Driver);
            SuiteStepsPage = new SuiteStepsPage(Driver);
            CaseStepsPage = new CaseStepsPage(Driver);
            ProjectTPStepsPage = new ProjectTPStepsPage(Driver);
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
