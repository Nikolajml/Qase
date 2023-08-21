using AngleSharp.Dom;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Qase.Core
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
