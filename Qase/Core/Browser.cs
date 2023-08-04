using AngleSharp;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qase.Utilities.Configuration;

namespace Qase.Core
{
    public class Browser
    {
        public Browser()
        {
            Driver = Configurator.BrowserType?.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            if (Driver != null) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public IWebDriver Driver { get; set; }
    }
}
