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
            _logger.Info($"User for LogIn: {user}");

            LoginPage.TryToLogin(user);
        }

        public bool IsPageOpened()
        {
            return ProjectsPage.IsPageOpened();        
        }
                


        public void NavigateToProjectForEditMixTest_MIX()
        {
            ProjectsPage.NavigateToProjectForMixTest();
        }
    }
}
