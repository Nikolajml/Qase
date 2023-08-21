using OpenQA.Selenium;
using Qase.Models;
using Qase.Tests.UI;
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

        //private readonly By EmailInputBy = By.XPath("//*[@name='email']");                   //By.Name("email");
        //private readonly By PasswordInputBy = By.XPath("//*[@name='password']");             //Name("password");
        //private readonly By RememberMeCheckboxBy = By.XPath("//*[@name='remember']");          //Name("remember");
        //private By SignInButtonBy = By.XPath("//*[@class='FzFLHc']");                        //ClassName("FzFLHc");

        private IWebElement EmailInputBy => Driver.FindElement(By.XPath("//*[@name='email']"));
        private IWebElement PasswordInputBy => Driver.FindElement(By.XPath("//*[@name='password']"));
        private IWebElement RememberMeCheckboxBy => Driver.FindElement(By.XPath("//*[@name='remember']"));
        private IWebElement SignInButtonBy => Driver.FindElement(By.XPath("//*[@class='FzFLHc']"));
                

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(RememberMeCheckboxBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        private void SetUserName(string username)
        {
            EmailInputBy.SendKeys(username);
        }

        private void SetPassword(string password)
        {
            PasswordInputBy.SendKeys(password);
        }

        private void ClickRememberMeCheckBox()
        {
            RememberMeCheckboxBy.Click();
        }

        private void ClickSignInButton()
        {
            SignInButtonBy.Click();
        }


        public void TryToLogin(User user)
        {
            SetUserName(user.Username);
            SetPassword(user.Password);
            ClickRememberMeCheckBox();
            ClickSignInButton();            
        }
    }
}
