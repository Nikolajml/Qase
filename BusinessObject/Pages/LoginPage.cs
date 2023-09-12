using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
                
        private IWebElement EmailInputBy => Driver.FindElement(By.XPath("//*[@name='email']"));
        private IWebElement PasswordInputBy => Driver.FindElement(By.XPath("//*[@name='password']"));
        private IWebElement RememberMeCheckboxBy => Driver.FindElement(By.XPath("//*[@name='remember']"));
        private IWebElement SignInButtonBy => Driver.FindElement(By.XPath("//*[@class='FzFLHc']"));


        public LoginPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }
        public LoginPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return RememberMeCheckboxBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
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
