using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string END_POINT = "projects";            

        private IWebElement CreateNewProjectButtonBy => Driver.FindElement(By.XPath("//button[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement ProjectTitleForMixTests => Driver.FindElement(By.XPath("(//*[@class='defect-title'])[3]"));

        public ProjectsPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public ProjectsPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"Projects Page opened status: {CreateNewProjectButtonBy.Displayed}");
            return CreateNewProjectButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {new Configurator().AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
        }

        public void NavigateToProjectForMixTest()
        {
            _logger.Debug($"Navigate to Projects for mix tests");
            ProjectTitleForMixTests.Click();
        }
    }
}
