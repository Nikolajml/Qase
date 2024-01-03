using Core.Utilities.Configuration;
using OpenQA.Selenium;

namespace Core.Core
{
    public class Browser
    {
        public Browser()
        {
            Driver = new Configurator().BrowserType?.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            if (Driver != null) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public IWebDriver Driver { get; set; }
    }
}
