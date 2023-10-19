using OpenQA.Selenium;
using NLog;
using Core.Core;

namespace UI.Pages.TestRunsPages
{
    public class CreatedTestRunPage : BasePage
    {
        private const string END_POINT = "/run/RUN/dashboard/1";

        //private IWebElement TestRun_Description => Driver.FindElement(By.XPath("//*[@class='toastui-editor-contents']"));       //(By.ClassName("toastui-editor-contents"));
        private By TestRun_DescriptionBy = By.XPath("//*[@class='toastui-editor-contents']");

        public CreatedTestRunPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public CreatedTestRunPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"PlanTP Page opened status: {Driver.FindElement(TestRun_DescriptionBy).Displayed}");
            return Driver.FindElement(TestRun_DescriptionBy).Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }

        public string GetTestRunDescription()
        {
            _logger.Debug($"Get test run description for assert");
            return Driver.FindElement(TestRun_DescriptionBy).Text;
        }

        public bool IsTestRunDescriptionVisiable()
        {
            _logger.Debug($"Checking that the test run description is visiable {TestRun_DescriptionBy}");
            return WaitService.GetVisibleElement(TestRun_DescriptionBy) != null;
        }
    }
}