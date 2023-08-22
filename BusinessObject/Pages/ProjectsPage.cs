using Core.Utilities.Configuration;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "projects";

        //private static readonly By CreateNewProjectButtonBy = By.Id("createButton");                

        private IWebElement CreateNewProjectButtonBy => Driver.FindElement(By.XPath("//button[@class='j4xaa7 u0i1tV J4xngT']"));

        public ProjectsPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public ProjectsPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return CreateNewProjectButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + END_POINT);
        }
    }
}
