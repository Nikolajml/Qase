using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;
using UI.Models;

namespace UI.Pages
{
    public class CasePage : BasePage
    {
        private const string END_POINT = "case/TP/create";

        private IWebElement CreateCaseButtonBy
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus"));
            }
        } // что такое Stale Element Exception?

        private IWebElement CaseNameInput => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SaveCaseButton => Driver.FindElement(By.XPath("//*[@id='save-case']"));     
                

        public CasePage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }
        public CasePage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"Case Page opened status: {SaveCaseButton.Displayed}");
            return SaveCaseButton.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");            
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }
           

        // Created case
        public void ClickToCaseButton()
        {
            _logger.Debug($"Click to create case button");
            CreateCaseButtonBy.Click();
        }

        public void SetCaseName(string caseName)
        {
            _logger.Debug($"Set case name: {caseName}");
            CaseNameInput.SendKeys(caseName);
        }

        public void ClickToSaveCaseButton()
        {
            _logger.Debug($"Click to 'Save Button' to save the created case");
            SaveCaseButton.Click();
        }

        // Edit case     
        public void ClickToCaseTitleField()
        {
            _logger.Debug($"Click to case title field");
            CaseNameInput.Click();
        }

        public void ClearCaseTitleField()
        {
            _logger.Debug($"Clear case title field");
            CaseNameInput.Clear();
        }
                
        public void SetEditedCaseName(string caseName)
        {
            _logger.Debug($"Set edited case name: {caseName}");
            CaseNameInput.Clear();
            CaseNameInput.SendKeys(caseName);
        }
    }
}
