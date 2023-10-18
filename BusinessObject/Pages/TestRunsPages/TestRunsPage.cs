using NLog;
using OpenQA.Selenium;

namespace UI.Pages.TestRuns
{
    public class TestRunsPage : BasePage
    {
        private const string END_POINT = "/run/RUN";

        private IWebElement CreateTestRun_Button => Driver.FindElement(By.ClassName("ZwgkIF"));
        
        public TestRunsPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public TestRunsPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"TestRunsPage opened status: {CreateTestRun_Button.Displayed}");
            return CreateTestRun_Button.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }

        // Create test runs
        public void ClickOnCreateTestRunButton()
        {
            _logger.Debug($"Click on the *CREATE TEST RUN BUTTON* to move to the *StartNewTestRunPopUpPage*");
            CreateTestRun_Button.Click();
        }

        
    }
}