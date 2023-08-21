using OpenQA.Selenium;

namespace Core.Core
{
    public static class ExpectedCondition
    {
        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
        {
            return delegate
            {
                try
                {
                    if (element.Displayed)
                    {
                        return element;
                    }

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }


        //private static IWebElement ElementIfVisible(IWebElement locator)
        //{
        //    if (!locator.Displayed)
        //    {
        //        return null;
        //    }

        //    return locator;
        //}
    }
}
