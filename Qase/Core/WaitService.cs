using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Core
{
    public class WaitService
    {
        [ThreadStatic] protected static IWebDriver? _driver;

        private WebDriverWait _wait;

        public WaitService(IWebDriver? driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement GetVisibleElement(IWebElement locator)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                throw new AssertionException(e.Message, e);
            }
        }

        public IAlert GetAlertOnPage()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return _wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public IWebElement ExistsElement(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver?>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
