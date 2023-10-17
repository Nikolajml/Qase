using OpenQA.Selenium;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages.TestRunsPages
{
    public class CreatedTestRunPage : BasePage
    {
        private const string END_POINT = "/run/RUN/dashboard/1";

        private IWebElement TestRun_Description => Driver.FindElement(By.XPath("//*[@class='toastui-editor-contents']"));       //(By.ClassName("toastui-editor-contents"));
        //private IWebElement Done_Button => Driver.FindElement(By.XPath("(//*[@class='j4xaa7 u0i1tV J4xngT'])[4]"));


        public CreatedTestRunPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public CreatedTestRunPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"PlanTP Page opened status: {TestRun_Description.Displayed}");
            return TestRun_Description.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }                

        public string GetTestRunDescription()
        {
            _logger.Debug($"Get test run description for assert");
            return TestRun_Description.GetAttribute("innerText");
        }



    }
}