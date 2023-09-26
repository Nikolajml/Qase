using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;
using UI.Models;

namespace UI.Pages
{
    public class CasePage : BasePage        // use logger Debug Info
    {
        private const string END_POINT = "case/TP/create";

        private IWebElement CreateCaseButtonBy
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus"));
            }
        } // что такое Stale Element Exception?

        private IWebElement CaseNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SaveCaseButtonBy => Driver.FindElement(By.XPath("//*[@id='save-case']"));     
                

        public CasePage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }
        public CasePage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return SaveCaseButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
        }
           

        // Created case
        public void ClickToCaseButton()
        {
            _logger.Debug($"Click to create case button");
            CreateCaseButtonBy.Click();
        }

        public void SetCaseName(string caseName)
        {
            _logger.Debug($"Set case name");
            CaseNameInputBy.SendKeys(caseName);
        }

        public void ClickToSaveCaseButton()
        {
            _logger.Debug($"Click to SaveButton to save the created case");
            SaveCaseButtonBy.Click();
        }

        // Edit case     
        public void ClickToCaseTitleField()
        {
            _logger.Debug($"Click to case title field");
            CaseNameInputBy.Click();
        }

        public void ClearCaseTitleField()
        {
            _logger.Debug($"Clear case title field");
            CaseNameInputBy.Clear();
        }
                
        public void SetEditedCaseName(string caseName)
        {
            _logger.Debug($"Set edited case name");
            CaseNameInputBy.Clear();
            CaseNameInputBy.SendKeys(caseName);
        }
    }
}
