using Core.Utilities.Configuration;
using OpenQA.Selenium;

namespace UI.Pages
{
    public class PlanTPPage : BasePage
    {
        private static string END_POINT = "plan/TP";

        //private readonly By CreatePlanButtonBy = By.XPath("//a[@id='createButton']");
        //private readonly By PlanTitleInputBy = By.XPath("//input[@id='title']");     //("title");
        //private readonly By PlanDescriptionInputBy = By.XPath("//*[@class='ProseMirror toastui-editor-contents']");       //By.CssSelector(".ww-mode .ProseMirror");
        //private readonly By AddCasesButtonBy = By.XPath("//button[@id='edit-plan-add-cases-button']");       //Id("edit-plan-add-cases-button");        
        //private readonly By ControlCaseIndicatorBy = By.CssSelector(".suites-column .suite:last-child .custom-control-indicator");
        //private readonly By DoneButtonBy = By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']");         //By.CssSelector(".CCVJRT .u0i1tV");
        //private readonly By SavePlanButtonBy = By.XPath("//*[@id='save-plan']");         //By.Id("save-plan");
        //private readonly By EllipsisButtonForPlanEditBy = By.XPath("//span[@class='ZwgkIF']");      //By.CssSelector(".HWdDFk .ZwgkIF");
        //private readonly By PlanEditButtonBy = By.XPath("(//a[@role='menuitem'])[2]");         //By.CssSelector("a[href^='/plan/TP/edit/']");        
        //private readonly By PlanTitleInputForClearBy = By.XPath("//*[@id='title']");         //By.Id("title");
        //private readonly By PlanTitleFieldClearBy = By.XPath("//*[@id='title']");        //By.Id("title");
        //private readonly By GetPlanTitleBy = By.XPath("//*[@class='defect-title']");      //By.ClassName("defect-title");
        //private readonly By GetPlanTitleForSecondAssertBy = By.XPath("//*[@class='plan-view-header-title']");        //By.ClassName("plan-view-header-title");
        //private readonly By GetPlanDescriptionForSecondAssertBy = By.XPath("//*[@class='toastui-editor-contents']");      //By.ClassName("toastui-editor-contents");

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
        private IWebElement GetPlanDescriptionForSecondAssertBy => Driver.FindElement(By.XPath("//*[@class='toastui-editor-contents']"));


        public PlanTPPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public PlanTPPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return CreatePlanButtonBy.Displayed;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + END_POINT);
            IsPageOpened();

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
    }
}
