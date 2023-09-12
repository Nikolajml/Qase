using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "projects";            

        private IWebElement CreateNewProjectButtonBy => Driver.FindElement(By.XPath("//button[@class='j4xaa7 u0i1tV J4xngT']"));

        public ProjectsPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public ProjectsPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return CreateNewProjectButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
        }
    }
}
