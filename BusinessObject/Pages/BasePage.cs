using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public abstract class BasePage
    {
        protected Configurator config = new Configurator();

        protected IWebDriver Driver;
        protected ILogger _logger;
        
        public BasePage(ILogger logger, IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            _logger = logger;   

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        public abstract void OpenPage();
        public abstract bool IsPageOpened();
    }
}
