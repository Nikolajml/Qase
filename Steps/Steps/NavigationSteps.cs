using Core.Utilities.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Pages;

namespace Steps.Steps
{
    public class NavigationSteps
    {        
        public LoginPage LoginPage;
        public ProjectsPage ProjectsPage;

        public NavigationSteps(IWebDriver driver)
        {
            LoginPage = new LoginPage(driver);
            ProjectsPage = new ProjectsPage(driver);
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
            Assert.IsTrue(ProjectsPage.IsPageOpened(), "The Projects Page wasn't opened");
        }
    }
}
