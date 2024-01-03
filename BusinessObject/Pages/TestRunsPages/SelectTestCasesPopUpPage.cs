using OpenQA.Selenium;
using NLog;

namespace UI.Pages.TestRuns
{
    public class SelectTestCasesPopUpPage : BasePage
    {
        private const string END_POINT = "/run/RUN";
                
        private IWebElement SelectCase_Indicator => Driver.FindElement(By.ClassName("custom-control-indicator"));
        private IWebElement Done_Button => Driver.FindElement(By.XPath("(//*[@class='j4xaa7 u0i1tV J4xngT'])[4]"));




        public SelectTestCasesPopUpPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public SelectTestCasesPopUpPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"PlanTP Page opened status: {Done_Button.Displayed}");
            return Done_Button.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }

        public void ClickOnSelectCaseIndicator()
        {
            _logger.Debug($"Click on the *SELECT CASE INDICATOR* to choice a case");
            SelectCase_Indicator.Click();
        }

        public void ClickOnDoneButton()
        {
            _logger.Debug($"Click on the *DONE BUTTON* to confirm the selected case");
            Done_Button.Click();
        }
    }
}
