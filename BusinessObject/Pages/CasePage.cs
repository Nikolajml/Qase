using Core.Utilities.Configuration;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class CasePage : BasePage
    {
        private static string END_POINT = "case/TP/create";        

        //private IWebElement SuiteButtonBy => Driver.FindElement(By.XPath("//*[@id='create-suite-button']"));
        //private IWebElement SuiteNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        //private IWebElement SuiteDescriptionInputBy => Driver.FindElement(By.XPath("//*[@id='description']"));
        //private IWebElement SuitePreconditionsInputBy => Driver.FindElement(By.XPath("//*[@id='preconditions']"));
        //private IWebElement CreateSuiteButtonBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        //private IWebElement EllipsisEditBy => Driver.FindElement(By.CssSelector(".hHBzWZ:last-child .SmsctB .fa-ellipsis-h"));
        //private IWebElement EditSuiteButtonBy => Driver.FindElement(By.XPath("//div[@class='Cr3S77']//i[@class='far fa-pencil']"));
        //private IWebElement SaveEditedSuiteBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        //private IWebElement SuiteNameInputForClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        //private IWebElement SuiteNameFieldClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        //private IWebElement SuiteNameEditBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement CreateCaseButtonBy => Driver.FindElement(By.CssSelector(".tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus"));
        private IWebElement CaseNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SaveCaseButtonBy => Driver.FindElement(By.XPath("//*[@id='save-case']"));
        //private IWebElement CreatedCaseTitle => Driver.FindElement(By.CssSelector(".Azji8w .EllwN3:nth-last-child(2) .wq7uNh"));
        //private IWebElement CaseEditBy => Driver.FindElement(By.CssSelector(".tgn4gT .J4xngT"));
        //private IWebElement SuiteNameTitleBy => Driver.FindElement(By.CssSelector(".hHBzWZ:last-child .fXc2Go"));

        private string SuiteNameByTextTeplmate => "//*[@title='{0}']";

        public CasePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public CasePage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened() // доработать - включить в степы, чтобы была проверка
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
