using Core.Utilities.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace Steps.UISteps
{
    public class NavigationSteps
    {       
        public LoginPage LoginPage => new LoginPage(Driver);
        protected IWebDriver Driver;

        public NavigationSteps(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToLoginPage()
        {
            LoginPage.OpenPage();
        }


        public ProjectsPage SuccessfulLogin(User user)
        {
            LoginPage.TryToLogin(user);
            return new ProjectsPage(Driver);
        }

        
    }
}
