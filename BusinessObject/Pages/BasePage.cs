using Core.Core;
using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public abstract class BasePage
    {
        protected WaitService WaitService;
        protected Configurator config;

        protected IWebDriver Driver;
        protected ILogger _logger;
        
        public BasePage(ILogger logger, IWebDriver driver, bool openPageByUrl)
        {            
            config = new Configurator();

            Driver = driver;
            _logger = logger;

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
