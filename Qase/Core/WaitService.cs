using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using AngleSharp.Dom;
using System.Xml.Linq;

namespace Core.Core
{
    public class WaitService
    {
        protected IWebDriver? _driver;

        private WebDriverWait _wait;

        public WaitService(IWebDriver? driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement? GetVisibleElement(By by)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                return null;
            }
        }











        //public IWebElement? GetVisibleElementElement(IWebElement by)
        //{
        //    try
        //    {
        //        return _wait.Until(ElementIsVisible1(by));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}


        //public static Func<IWebDriver, IWebElement> ElementIsVisible1(By locator)
        //{
        //    return delegate (IWebDriver driver)
        //    {
        //        try
        //        {
        //            return ElementIfVisible1(driver.FindElement(locator));
        //        }
        //        catch (StaleElementReferenceException)
        //        {
        //            return null;
        //        }
        //    };
        //}


        //private static IWebElement ElementIfVisible1(IWebElement element)
        //{
        //    if (!element.Displayed)
        //    {
        //        return null;
        //    }

        //    return element;
        //}
    }
}
