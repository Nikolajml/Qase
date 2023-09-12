using Allure.Commons;
using Bogus;
using Core.Client;
using Core.Core;
using Core.Utilities.Configuration;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Steps.Steps;
namespace Tests
{
    [AllureNUnit]
    public class CommonBaseTest
    {
        public string? BaseUrl;
        protected IWebDriver Driver;
        protected ILogger logger;
        protected ApiClient _apiClient;
        protected Configurator config;

        private AllureLifecycle _allure;
        public Faker Faker = new Faker();

        public NavigationSteps NavigationSteps;


        [OneTimeSetUp]
        public void Setup()
        {
            config = new Configurator();
            BaseUrl = config.AppSettings.URL;
            _apiClient = new ApiClient(new Configurator().Bearer);
            logger = LogManager.GetCurrentClassLogger();

            Driver = new Browser().Driver;
            _allure = AllureLifecycle.Instance;

            NavigationSteps = new NavigationSteps(logger, Driver);          
        }

        [OneTimeTearDown]
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
