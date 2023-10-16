using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;
using UI.Models;

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
            _logger.Debug($"Login Page opened status: {RememberMeCheckboxBy.Displayed}");
            return RememberMeCheckboxBy.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }

        private void SetUserName(string username)
        {
            _logger.Debug($"Set user name: {username}");
            EmailInputBy.SendKeys(username);
        }

        private void SetPassword(string password)
        {
            _logger.Debug($"Set pasword: {password}");
            PasswordInputBy.SendKeys(password);
        }

        private void ClickRememberMeCheckBox()
        {
            _logger.Debug($"Click to RememberMe");
            RememberMeCheckboxBy.Click();
        }

        private void ClickSignInButton()
        {
            _logger.Debug($"Click to Sign In");
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
