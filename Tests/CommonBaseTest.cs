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
        protected ApiClient _apiClient;
        protected Configurator config;

        private AllureLifecycle _allure;
        public Faker Faker = new Faker();

        [OneTimeSetUp]
        public void Setup()
        {
            config = new Configurator();
            BaseUrl = config.AppSettings.URL;
            _apiClient = new ApiClient(new Configurator().Bearer);

            Driver = new Browser().Driver;
            _allure = AllureLifecycle.Instance;
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
