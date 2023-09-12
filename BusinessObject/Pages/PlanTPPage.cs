using Core.Utilities.Configuration;
using NLog;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class PlanTPPage : BasePage
    {
        private static string END_POINT = "plan/TP";                

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
            return CreatePlanButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(new Configurator().AppSettings.URL + END_POINT);
        }


        // CREATE PLAN
        public void ClickToCreatePlanButton()
        {
            CreatePlanButtonBy.Click();
        }

        public void SetPlanTitle(string planTitle)
        {
            PlanTitleInputBy.SendKeys(planTitle);
        }

        public void SetPlanDescription(string planDescription)
        {
            PlanDescriptionInputBy.SendKeys(planDescription);
        }

        public void ClickToAddCaseButton()
        {
            AddCasesButtonBy.Click();
        }

        public void ClickToControlIndicatorToChooseCase()
        {
            ControlCaseIndicatorBy.Click();
        }

        public void ClickToDoneButton()
        {
            DoneButtonBy.Click();
        }

        public void ClickToSavePlanButton()
        {
            SavePlanButtonBy.Click();
        }

        // Second assert for created Plan
        public void ClickToCreatedPlanTitleToAssert()
        {
            Thread.Sleep(1000);
            GetPlanTitleBy.Click();
        }

        public string GetPlanTitleForSecondAssert()
        {
            return GetPlanTitleForSecondAssertBy.Text;
        }

        public string GetPlanDescriptionForSecondAssert()
        {
            return GetPlanDescriptionForSecondAssertBy.GetAttribute("innerText");
        }

        // EDIT PLAN
        public void ClickToEllipsis()
        {
            EllipsisButtonForPlanEditBy.Click();
        }

        public void ClickToEdit()
        {
            PlanEditButtonBy.Click();
        }

        public void ClickToClearTitlePlanField()
        {            
            PlanTitleInputForClearBy.Click();
            Thread.Sleep(1000);
        }

        public void ClearTitlePlanField()
        {
            PlanTitleFieldClearBy.Clear();
            
        }

        public void EditPlanTitle(string planTitle)
        {            
            PlanTitleInputBy.SendKeys(planTitle);
        }

        public void ClickToSaveEditButton()
        {
            SavePlanButtonBy.Click();
        }


        // METHOD TO ASSERT
        public string GetPlanTitle()
        {
            return GetPlanTitleBy.GetAttribute("innerText");
        }

        // METHOD TO ASSERT
        public void DeletePlan()
        {
            ClickToEllipsis();
            ClickToDeletePlanButton();
            ClickToConfirmDeletePlanButton();
        }

        public void ClickToDeletePlanButton()
        {
            PlanDeleteButton.Click();
        }

        public void ClickToConfirmDeletePlanButton()
        {
            ConfirmPlanDeleteButton.Click();
        }
        
    }
}
