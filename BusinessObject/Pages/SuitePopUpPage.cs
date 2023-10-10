using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class SuitePopUpPage : BasePage
    {
        private static string END_POINT = "project/TP";
        
        private IWebElement SuiteNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SuiteDescriptionInputBy => Driver.FindElement(By.XPath("//*[@id='description']"));
        private IWebElement SuitePreconditionsInputBy => Driver.FindElement(By.XPath("//*[@id='preconditions']"));
        private IWebElement CreateSuiteButtonBy => Driver.FindElement(By.XPath("(//span[@class='ZwgkIF'])[7]"));  // // (//span[@class='ZwgkIF'])[7]\")   //*[@class='j4xaa7 u0i1tV J4xngT']"       
        private IWebElement SaveEditedSuiteBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement SuiteNameInputForClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement SuiteNameFieldClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement SuiteNameEditBy => Driver.FindElement(By.XPath("//*[@id='title']"));        
        private IWebElement SuiteNameTitleBy => Driver.FindElement(By.CssSelector(".hHBzWZ:last-child .fXc2Go"));  
        private IWebElement DeleteSuiteIcon => Driver.FindElement(By.XPath("(//span[@class='ZwgkIF'])[8]"));
        private IWebElement DeleteSuiteButton => Driver.FindElement(By.XPath("//button[@class='j4xaa7 b_jd28 J4xngT']"));
        private IWebElement EditSuiteIcon => Driver.FindElement(By.XPath("(//*[@class='j4xaa7 Jn_dMk J4xngT HWdDFk'])[1]"));

        private string SuiteNameByTextTeplmate => "//*[@title='{0}']";

        public SuitePopUpPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }
        public SuitePopUpPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"SuitePopUp Page opened status: {CreateSuiteButtonBy.Displayed}");
            return CreateSuiteButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {new Configurator().AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
        }
                        

        public void SetSuiteName(string suiteName)
        {
            _logger.Debug($"Set suite name: {suiteName}");
            SuiteNameInputBy.SendKeys(suiteName);
        }

        public void SetSuiteDescriptione(string suiteDescription)
        {
            _logger.Debug($"Set suite description: {suiteDescription}");
            SuiteDescriptionInputBy.SendKeys(suiteDescription);
        }
        public void SetSuitePreconditionse(string suitePreconditions)
        {
            _logger.Debug($"Set suite precondition: {suitePreconditions}");
            SuitePreconditionsInputBy.SendKeys(suitePreconditions);
        }

        public void ClickToCreateSuiteButton()
        {
            _logger.Debug($"Click on the 'Create suite button'");
            CreateSuiteButtonBy.Click();
        }

        // Edit suite      
        public void ClickToEditSuiteIcon()
        {
            _logger.Debug($"Click on the 'EditSuiteIcon'");
            EditSuiteIcon.Click();
        }

        public void ClickToClearNameField()
        {
            _logger.Debug($"Click to clear name field");
            SuiteNameInputForClearBy.Click();
        }

        public void ClearNameField()
        {
            _logger.Debug($"Clear name field");
            SuiteNameFieldClearBy.Clear();
        }

        public void EditSuiteName(string suiteName)
        {
            _logger.Debug($"Edit suite name {suiteName}");
            SuiteNameEditBy.SendKeys(suiteName);
        }

        public void ClickToSaveEditButton()
        {
            _logger.Debug($"Click on the 'SaveEditButton'");
            SaveEditedSuiteBy.Click();
        }
                    

        // Method for delete suite
        public void DeleteSuite()
        {
            ClickToDeleteSuiteIcon();
            ClickToDeleteSuiteButton();
        }

        private void ClickToDeleteSuiteIcon()
        {
            DeleteSuiteIcon.Click();
        }

        private void ClickToDeleteSuiteButton()
        {
            DeleteSuiteButton.Click();
        }
    }
}