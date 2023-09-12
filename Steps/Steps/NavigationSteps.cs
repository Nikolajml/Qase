using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;
using UI.Pages;

namespace Steps.Steps
{
    public class NavigationSteps
    {        
        public LoginPage LoginPage;
        public ProjectsPage ProjectsPage;
        protected ILogger _logger;

        public NavigationSteps(ILogger logger, IWebDriver driver)
        {
            LoginPage = new LoginPage(logger, driver);
            ProjectsPage = new ProjectsPage(logger, driver);

            _logger = logger;
        }


        public void NavigateToLoginPage()
        {
            LoginPage.OpenPage();
        }

        public void SuccessfulLogin(User user)
        {
            LoginPage.TryToLogin(user);
        }

        public void CheckThatPageIsOpen()
        {
            ProjectsPage.IsPageOpened();
        }
    }
}
