using NLog;
using OpenQA.Selenium;
using Qase.Core;
using Qase.Utilities.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WaitService WaitService;

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        public abstract void OpenPage();
        public abstract bool IsPageOpened();
    }
}
