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
        public ProjectsPage ProjectsPage => new ProjectsPage(Driver);
        protected IWebDriver Driver;

        public NavigationSteps(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToLoginPage()
        {
            LoginPage.OpenPage();
        }


        public void SuccessfulLogin(User user)
        {
            LoginPage.TryToLogin(user);            
                                    
        }

        public void CheckThatPageIsOpened()
        {
            ProjectsPage.IsPageOpened();
        }
                
    }
}
