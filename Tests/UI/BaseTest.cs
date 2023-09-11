using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using UI.Pages;
using Core.Utilities.Configuration;
using Steps.Steps;
using Core.Core;
using Core.Utilities;
using Bogus;
using Tests.API;

namespace Tests.UI
{
    [AllureNUnit]
    public class BaseTest : BaseApiTest     // неправильно - CommonBaseTest
    {
        public readonly string? BaseUrl = new Configurator().AppSettings.URL;

        protected IWebDriver Driver;

        private AllureLifecycle _allure;       
        public Faker Faker = new Faker();
          
        public NavigationSteps NavigationSteps;
        

        [OneTimeSetUp] 
        public void Setup()
        {
            Driver = new Browser().Driver;
            _allure = AllureLifecycle.Instance;
           
            NavigationSteps = new NavigationSteps(Driver);  

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(new Configurator().Admin);          // не создавать каждый раз new Configurator
            NavigationSteps.CheckThatPageIsOpen();          // use assert inconclusive
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
