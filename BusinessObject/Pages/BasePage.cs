using OpenQA.Selenium;

namespace UI.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;



        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        public abstract void OpenPage();
        public abstract bool IsPageOpened();
    }
}
