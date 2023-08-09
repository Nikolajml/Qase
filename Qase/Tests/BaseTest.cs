using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using Qase.Core;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;
using Qase.Utilities.Configuration;

namespace Qase.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected IWebDriver Driver;
        private AllureLifecycle _allure;
        public LoginPage LoginPage { get; set; }


        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;                       
            _allure = AllureLifecycle.Instance;
            LoginPage = new LoginPage(Driver);

            LoginPage.OpenPage();
            LoginPage.TryToLogin(Configurator.Admin);
            Thread.Sleep(2000);
        }

        [TearDown]
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

            //Driver.Quit();
            //Driver.Dispose();
        }
    }
}
