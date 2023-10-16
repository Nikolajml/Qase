using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class ProjectTPPage : BasePage
    {
        private static string END_POINT = "project/TP";
                
        private IWebElement SuiteButtonBy => Driver.FindElement(By.XPath("//*[@id='create-suite-button']"));
        private IWebElement SuiteNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SuiteDescriptionInputBy => Driver.FindElement(By.XPath("//*[@id='description']"));
        private IWebElement SuitePreconditionsInputBy => Driver.FindElement(By.XPath("//*[@id='preconditions']"));
        private IWebElement CreateSuiteButtonBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement EllipsisEditBy => Driver.FindElement(By.CssSelector(".hHBzWZ:last-child .SmsctB .fa-ellipsis-h"));
        private IWebElement EditSuiteButtonBy => Driver.FindElement(By.XPath("//div[@class='Cr3S77']//i[@class='far fa-pencil']"));
        private IWebElement SaveEditedSuiteBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement SuiteNameInputForClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement SuiteNameFieldClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement SuiteNameEditBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement CreateCaseButtonBy => Driver.FindElement(By.XPath("//*[@class='btn me-2 btn-primary'][2]")); //.tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus
        private IWebElement CreatedCaseTitle => Driver.FindElement(By.CssSelector(".Azji8w .EllwN3:nth-last-child(2) .wq7uNh"));
        private IWebElement CaseEditBy => Driver.FindElement(By.CssSelector(".tgn4gT .J4xngT"));
        private IWebElement SuiteNameTitleBy => Driver.FindElement(By.CssSelector(".hHBzWZ:last-child .fXc2Go"));
        private IWebElement DefectsCategoryPanel => Driver.FindElement(By.XPath("//*[@aria-label='Defects']"));
        private IWebElement PlansCategoryPanel => Driver.FindElement(By.XPath("//*[@aria-label='Test Plans']"));    
        private string SuiteNameByTextTeplmate => "//*[@title='{0}']";

        public ProjectTPPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }
        public ProjectTPPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"Page opened status: {SuiteButtonBy.Displayed}");
            return SuiteButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }

        // Create suite
        public void ClickToSuiteButton()
        {
            _logger.Debug($"Click to 'SuiteButton'");
            SuiteButtonBy.Click();
        }

        public void SetSuiteName(string suiteName)
        {
            _logger.Debug($"Set suite name: {suiteName}");
            SuiteNameInputBy.SendKeys(suiteName);
        }

        public void SetSuiteDescriptione(string suiteDescription)
        {
            _logger.Debug($"Set suite name: {suiteDescription}");
            SuiteDescriptionInputBy.SendKeys(suiteDescription);
        }
        public void SetSuitePreconditionse(string suitePreconditions)
        {
            _logger.Debug($"Set suite name: {suitePreconditions}");
            SuitePreconditionsInputBy.SendKeys(suitePreconditions);
        }

        public void ClickToCreateSuiteButton()
        {
            _logger.Debug($"Click to 'CreateSuiteButton'");
            CreateSuiteButtonBy.Click();
        }

        //Edit suite
        public void ClickToEllipsis()
        {
            _logger.Debug($"Click on the 'Elipsis'");
            EllipsisEditBy.Click();
        }

        public void ClickToEdit()
        {
            _logger.Debug($"Click on the 'Edit'");
            EditSuiteButtonBy.Click();
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
            _logger.Debug($"Click on the'SaveEditButton' to save edited suite");
            SaveEditedSuiteBy.Click();
        }

        // Created case
        public void ClickToCaseButton()
        {
            _logger.Debug($"Click on the'CaseButton' to create case");
            CreateCaseButtonBy.Click();
        }    
              
        // Methods to assert
        public string GetSuiteName()
        {
            _logger.Debug($"Get suite name to assert");
            return SuiteNameTitleBy.GetAttribute("innerText");
        }

        public string GetSuiteNameByText(string text)
        {
            var locator = string.Format(SuiteNameByTextTeplmate, text);
            return Driver.FindElement(By.XPath(locator)).GetAttribute("innerText");
        }                

        public string GetCreatedCaseTitle()
        {
            _logger.Debug($"Get created case title");
            return CreatedCaseTitle.GetAttribute("innerText");
        }

        // Navigate to edit Case
        public void ClickToCaseTitle()
        {
            _logger.Debug($"Click on the 'CaseTitle'");
            CreatedCaseTitle.Click();
        }

        public void ClickToCaseEdit()
        {
            _logger.Debug($"Click on the 'CaseEdit' to edit the case");
            CaseEditBy.Click();
        }


        // Methods for Navigate to Defects Category
        public void NavigateToDefectsPage()
        {
            _logger.Debug($"Navigate to DEFECTS category");
            DefectsCategoryPanel.Click();
        }


        // Methods for Navigate to Plans Category
        public void NavigateToPlansPage()
        {
            _logger.Debug($"Navigate to PLANS category");
            PlansCategoryPanel.Click();
        }
    }
}
