using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class CasePage : BasePage
    {
        private static string END_POINT = "case/TP/create";        
                
        private IWebElement CreateCaseButtonBy => Driver.FindElement(By.CssSelector(".tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus"));
        private IWebElement CaseNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SaveCaseButtonBy => Driver.FindElement(By.XPath("//*[@id='save-case']"));     

        private string SuiteNameByTextTeplmate => "//*[@title='{0}']";

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
           

        // CREATED CASE
        public void ClickToCaseButton()
        {
            CreateCaseButtonBy.Click();
        }

        public void SetCaseName(string caseName)
        {
            CaseNameInputBy.SendKeys(caseName);
        }

        public void ClickToSaveCaseButton()
        {
            SaveCaseButtonBy.Click();
        }

        // EDIT CASE
        

        public void ClickToCaseTitleField()
        {
            CaseNameInputBy.Click();
        }

        public void ClearCaseTitleField()
        {
            CaseNameInputBy.Clear();
        }
                
        public void SetEditedCaseName(string caseName)
        {
            CaseNameInputBy.Clear();
            CaseNameInputBy.SendKeys(caseName);
        }
    }
}
