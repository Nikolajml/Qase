using OpenQA.Selenium;
using NLog;

namespace UI.Pages.TestRuns
{
    public class StartNewTestRunPopUpPage : BasePage
    {
        private const string END_POINT = "/run/RUN";

        private IWebElement Description_Input => Driver.FindElement(By.XPath("(//*[@class='gYZSEd'])[2]"));
        private IWebElement SelectCase_Button => Driver.FindElement(By.CssSelector(".lLm7nE .ZwgkIF"));
        private IWebElement StartRun_Button => Driver.FindElement(By.CssSelector(".CCVJRT .u0i1tV"));


        public StartNewTestRunPopUpPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public StartNewTestRunPopUpPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"StartNewTestRunPopUpPage opened status: {StartRun_Button.Displayed}");
            return StartRun_Button.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }


        public void ClickOnDescriptionField()
        {
            _logger.Debug($"Click on the description field to set a run description");
            Description_Input.Click();
        }

        public void SetTestRunDescription(string runDescription)
        {
            _logger.Debug($"Set a test run description");
            Description_Input.SendKeys(runDescription);
        }
               

        public void ClickOnSelectCaseButton()
        {
            _logger.Debug($"Click on the *SELECT CASE BUTTON* to move to the *SelectTestCasesPopUpPage*");
            SelectCase_Button.Click();
        }

        public void ClickOnStartRunButton()
        {
            _logger.Debug($"Click on the *CREATE RUN BUTTON* to create test run");
            StartRun_Button.Click();
        }
    }
}
