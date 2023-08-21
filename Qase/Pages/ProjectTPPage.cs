using OpenQA.Selenium;
using Qase.Models;
using Qase.Tests.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Pages
{
    public class ProjectTPPage : BasePage
    {
        private static string END_POINT = "project/TP";

        //private static readonly By SuiteButtonBy = By.XPath("//*[@id='create-suite-button']");        //By.Id("create-suite-button");
        //private static readonly By SuiteNameInputBy = By.XPath("//*[@id='title']");            //By.Id("title");
        //private static readonly By SuiteDescriptionInputBy = By.XPath("//*[@id='description']");        //By.Id("description");
        //private static readonly By SuitePreconditionsInputBy = By.XPath("//*[@id='preconditions']");     //By.Id("preconditions");
        //private static readonly By CreateSuiteButtonBy = By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']");           //By.XPath("(//*[@class='j4xaa7 u0i1tV J4xngT'])[4]");       //By.CssSelector(".CCVJRT .u0i1tV .ZwgkIF");
        //private static readonly By EllipsisEditBy = By.CssSelector(".hHBzWZ:last-child .SmsctB .fa-ellipsis-h");
        //private static readonly By EditSuiteButtonBy = By.XPath("//div[@class='Cr3S77']//i[@class='far fa-pencil']");         //By.CssSelector(".yxKHfs .Cr3S77 .fa-pencil");
        //private static readonly By SaveEditedSuiteBy = By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']");         //By.CssSelector(".gyRSLD .u0i1tV");
        //private static readonly By SuiteNameInputForClearBy = By.XPath("//*[@class='XRXnTf']");
        //private static readonly By SuiteNameFieldClearBy = By.XPath("//*[@class='XRXnTf']");
        //private static readonly By SuiteNameEditBy = By.XPath("//*[@id='title']");       //By.Id("title");
        //private static readonly By CreateCaseButtonBy = By.CssSelector(".tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus");
        //private static readonly By CaseNameInputBy = By.XPath("//*[@id='title']");       //By.Id("title");
        //private static readonly By SaveCaseButtonBy = By.XPath("//*[@id='save-case']");      //By.Id("save-case");        
        //private static readonly By CreatedCaseTitle = By.CssSelector(".Azji8w .EllwN3:nth-last-child(2) .wq7uNh");
        //private static readonly By CaseEditBy = By.CssSelector(".tgn4gT .J4xngT");
        //private static readonly By SuiteNameTitleBy = By.CssSelector(".hHBzWZ:last-child .fXc2Go");

        //private IWebElement CreateNewProjectButtonBy => Driver.FindElement(By.Id("createButton"));

        private IWebElement SuiteButtonBy => Driver.FindElement(By.XPath("//*[@id='create-suite-button']"));
        private IWebElement SuiteNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SuiteDescriptionInputBy => Driver.FindElement(By.XPath("//*[@id='description']"));
        private IWebElement SuitePreconditionsInputBy => Driver.FindElement(By.XPath("//*[@id='preconditions']"));
        private IWebElement CreateSuiteButtonBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement EllipsisEditBy => Driver.FindElement(By.XPath(".hHBzWZ:last-child .SmsctB .fa-ellipsis-h"));
        private IWebElement EditSuiteButtonBy => Driver.FindElement(By.XPath("//div[@class='Cr3S77']//i[@class='far fa-pencil']"));
        private IWebElement SaveEditedSuiteBy => Driver.FindElement(By.XPath("//*[@class='j4xaa7 u0i1tV J4xngT']"));
        private IWebElement SuiteNameInputForClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement SuiteNameFieldClearBy => Driver.FindElement(By.XPath("//*[@class='XRXnTf']"));
        private IWebElement SuiteNameEditBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement CreateCaseButtonBy => Driver.FindElement(By.XPath(".tXTVFF .yxKHfs:nth-child(3) .Cr3S77:nth-child(2) .fa-plus"));
        private IWebElement CaseNameInputBy => Driver.FindElement(By.XPath("//*[@id='title']"));
        private IWebElement SaveCaseButtonBy => Driver.FindElement(By.XPath("//*[@id='save-case']"));
        private IWebElement CreatedCaseTitle => Driver.FindElement(By.XPath(".Azji8w .EllwN3:nth-last-child(2) .wq7uNh"));
        private IWebElement CaseEditBy => Driver.FindElement(By.XPath(".tgn4gT .J4xngT"));
        private IWebElement SuiteNameTitleBy => Driver.FindElement(By.XPath(".hHBzWZ:last-child .fXc2Go"));

        public ProjectTPPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }
        public ProjectTPPage(IWebDriver driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(SuiteButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }


        // CREATE SUITE
        public void ClickToSuiteButton()
        {
            SuiteButtonBy.Click();
        }

        public void SetSuiteName(string suiteName)
        {
            SuiteNameInputBy.SendKeys(suiteName);
        }

        public void SetSuiteDescriptione(string suiteDescription)
        {
            SuiteDescriptionInputBy.SendKeys(suiteDescription);
        }
        public void SetSuitePreconditionse(string suitePreconditions)
        {
            SuitePreconditionsInputBy.SendKeys(suitePreconditions);
        }

        public void ClickToCreateSuiteButton()
        {
            CreateSuiteButtonBy.Click();
        }


        //EDIT SUITE
        public void ClickToEllipsis()
        {
            EllipsisEditBy.Click();
        }

        public void ClickToEdit()
        {
            EditSuiteButtonBy.Click();
        }

        public void ClickToClearNameField()
        {
            SuiteNameInputForClearBy.Click();
        }

        public void ClearNameField()
        {
            SuiteNameFieldClearBy.Clear();
        }

        public void EditSuiteName(string suiteName)
        {
            SuiteNameEditBy.SendKeys(suiteName);
        }

        public void ClickToSaveEditButton()
        {
            SaveEditedSuiteBy.Click();
        }


        // WAIT FOR EDITE SUITE
        public bool WaitInputNameFieldEditSuite()
        {
            return WaitService.GetVisibleElement(SuiteNameInputForClearBy) != null;
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


        // WAIT FOR CREATE CASE
        public bool WaitInputNameFieldCreateCase()
        {
            return WaitService.GetVisibleElement(CaseNameInputBy) != null;
        }

        public bool WaitCaseTitle()
        {
            return WaitService.GetVisibleElement(CreatedCaseTitle) != null;
        }


        // EDIT CASE
        public void ClickToCaseTitle()
        {
            CreatedCaseTitle.Click();
        }

        public void ClickToCaseEdit()
        {
            CaseEditBy.Click();
        }

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
            CaseNameInputBy.SendKeys(caseName);
        }


        // WAIT FOR EDIT CASE
        public bool WaitCaseEditButton()
        {
            return WaitService.GetVisibleElement(CaseEditBy) != null;
        }
        public bool WaitCaseNameInputField()
        {
            return WaitService.GetVisibleElement(CaseNameInputBy) != null;
        }

        public bool WaitSuiteName()
        {
            return WaitService.GetVisibleElement(SuiteNameTitleBy) != null;
        }


        // METHODS TO ASSERTS
        public string GetSuiteName()
        {
            return SuiteNameTitleBy.GetAttribute("innerText");
        }

        public string GetCreatedCaseTitle()
        {
            return CreatedCaseTitle.GetAttribute("innerText");
        }
    }
}
