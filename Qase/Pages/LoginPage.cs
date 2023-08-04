using OpenQA.Selenium;
using Qase.Models;
using Qase.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        private static readonly By EmailInputBy = By.Name("email");
        private static readonly By PasswordInputBy = By.Name("password");
        private static readonly By RememberMeCheckboxBy = By.Name("remember");
        private static readonly By SignInButtonBy = By.ClassName("FzFLHc");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(SignInButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        private void SetUserName(string username)
        {
            Driver.FindElement(EmailInputBy).SendKeys(username);
        }

        private void SetPassword(string password)
        {
            Driver.FindElement(PasswordInputBy).SendKeys(password);
        }

        private void ClickRememberMeCheckBox()
        {
            Driver.FindElement(RememberMeCheckboxBy).Click();
        }

        private void ClickSignInButton()
        {
            Driver.FindElement(SignInButtonBy).Click();
        }


        public ProjectsPage TryToLogin(User user)
        {
            SetUserName(user.Username);
            SetPassword(user.Password);
            ClickRememberMeCheckBox();
            ClickSignInButton();
            return new ProjectsPage(Driver);
        }
    }
}
