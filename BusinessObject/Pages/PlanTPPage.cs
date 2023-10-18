using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class PlanTPPage : BasePage
    {
        private const string END_POINT = "plan/TP";                

        private IWebElement CreatePlanButtonBy => Driver.FindElement(By.XPath("//a[@id='createButton']"));
        private IWebElement PlanTitleInputBy => Driver.FindElement(By.XPath("//input[@id='title']"));
        private IWebElement PlanDescriptionInputBy => Driver.FindElement(By.XPath("//*[@class='ProseMirror toastui-editor-contents']"));
        private IWebElement AddCasesButtonBy => Driver.FindElement(By.XPath("//button[@id='edit-plan-add-cases-button']"));
        private IWebElement ControlCaseIndicatorBy => Driver.FindElement(By.CssSelector(".suites-column .suite:last-child .custom-control-indicator"));
        private IWebElement DoneButtonBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement SavePlanButtonBy => Driver.FindElement(By.XPath("//*[@id='save-plan']"));
        private IWebElement EllipsisButtonForPlanEditBy => Driver.FindElement(By.XPath("//span[@class='ZwgkIF']"));
        private IWebElement PlanEditButtonBy => Driver.FindElement(By.XPath("(//a[@role='menuitem'])[2]"));
        private IWebElement PlanTitleInputForClearBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement PlanTitleFieldClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement GetPlanTitleBy => Driver.FindElement(By.XPath("//*[@class='defect-title']"));
        private IWebElement GetPlanTitleForSecondAssertBy => Driver.FindElement(By.XPath("//*[@class='plan-view-header-title']"));
        private IWebElement GetPlanDescriptionForSecondAssertBy => Driver.FindElement(By.XPath("//*[@class='toastui-editor-contents']")); ////*[@class='testcase-title']
        private IWebElement PlanDeleteButton => Driver.FindElement(By.XPath("(//button[@role='menuitem'])[2]"));
        private IWebElement ConfirmPlanDeleteButton => Driver.FindElement(By.XPath("//button[@class='j4xaa7 b_jd28 J4xngT']"));
                

        public PlanTPPage(ILogger logger, IWebDriver driver, bool openPageByUrl) : base(logger, driver, openPageByUrl)
        {

        }

        public PlanTPPage(ILogger logger, IWebDriver driver) : base(logger, driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            _logger.Debug($"PlanTP Page opened status: {CreatePlanButtonBy.Displayed}");
            return CreatePlanButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            _logger.Debug($"Navigate to {config.AppSettings.URL + END_POINT}");
            Driver.Navigate().GoToUrl(config.AppSettings.URL + END_POINT);
        }


        // Create plan
        public void ClickToCreatePlanButton()
        {
            _logger.Debug($"Click on the 'CreatePlanButton'");
            CreatePlanButtonBy.Click();
        }

        public void SetPlanTitle(string planTitle)
        {
            _logger.Debug($"Set plan title: {planTitle}");
            PlanTitleInputBy.SendKeys(planTitle);
        }

        public void SetPlanDescription(string planDescription)
        {
            _logger.Debug($"Set plan description: {planDescription}");
            PlanDescriptionInputBy.SendKeys(planDescription);
        }

        public void ClickToAddCaseButton()
        {
            _logger.Debug($"Click on the 'AddCaseButton'");
            AddCasesButtonBy.Click();
        }

        public void ClickToControlIndicatorToChooseCase()
        {
            _logger.Debug($"Click on the 'ControlIndicator' to choose case");
            ControlCaseIndicatorBy.Click();
        }

        public void ClickToDoneButton()
        {
            _logger.Debug($"Click on the 'DoneButton'");
            DoneButtonBy.Click();
        }

        public void ClickToSavePlanButton()
        {
            _logger.Debug($"Click on the 'SavePlanButton'");
            SavePlanButtonBy.Click();
        }

        // Second assert for created Plan
        public void ClickToCreatedPlanTitleToAssert()
        {
            _logger.Debug($"Click on the 'CreatedPlanTitle' to assert");
            Thread.Sleep(1000);
            GetPlanTitleBy.Click();
        }

        public string GetPlanTitleForSecondAssert()
        {
            _logger.Debug($"Get plan title for the second assert");
            return GetPlanTitleForSecondAssertBy.Text;
        }

        public string GetPlanDescriptionForSecondAssert()
        {
            _logger.Debug($"Get plan description for the second assert");
            return GetPlanDescriptionForSecondAssertBy.GetAttribute("innerText");
        }

        // Edit plan
        public void ClickToEllipsis()
        {
            _logger.Debug($"Click on the 'Ellipsis'");
            EllipsisButtonForPlanEditBy.Click();
        }

        public void ClickToEdit()
        {
            _logger.Debug($"Click on the 'Edit'");
            PlanEditButtonBy.Click();
        }

        public void ClickToClearTitlePlanField()
        {
            _logger.Debug($"Click to clear title plan field");
            PlanTitleInputForClearBy.Click();
            Thread.Sleep(1000);
        }

        public void ClearTitlePlanField()
        {
            _logger.Debug($"Clear title plan field");
            PlanTitleFieldClearBy.Clear();
            
        }

        public void EditPlanTitle(string planTitle)
        {
            _logger.Debug($"Edit plan title: {planTitle}");
            PlanTitleInputBy.SendKeys(planTitle);
        }

        public void ClickToSaveEditButton()
        {
            _logger.Debug($"Click to save 'EditButton'");
            SavePlanButtonBy.Click();
        }

        // Method for assert
        public string GetPlanTitle()
        {
            _logger.Debug($"Get plan title for assert");
            return GetPlanTitleBy.GetAttribute("innerText");
        }

        // Methods for delete plan 
        public void ClickToDeletePlanButton()
        {
            _logger.Debug($"Click to delete plan");
            PlanDeleteButton.Click();
        }

        public void ClickToConfirmDeletePlanButton()
        {
            _logger.Debug($"Click to confirm delete plan");
            ConfirmPlanDeleteButton.Click();
        }        
    }
}
