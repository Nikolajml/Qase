using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

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


    //    public IWebElement? GetVisibleElement(IWebElement element)
    //    {
    //        try
    //        {
    //            return _wait.Until(ElementIsVisible(element));
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }

    //    public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
    //    {
    //        return delegate (IWebDriver driver)
    //        {
    //            try
    //            {
    //                return ElementIfVisible(element);
    //            }
    //            catch (StaleElementReferenceException)
    //            {
    //                return null;
    //            }
    //        };
    //    }

    //    private static IWebElement ElementIfVisible(IWebElement element)
    //    {
    //        if (!element.Displayed)
    //        {
    //            return null;
    //        }

    //        return element;
    //    }
    }
}
