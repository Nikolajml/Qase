using OpenQA.Selenium;
using Qase.Models;
using Qase.Tests;
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

        private static readonly By SuiteButtonBy = By.Id("create-suite-button");
        private static readonly By SuiteNameInputBy = By.Id("title");
        private static readonly By SuiteDescriptionInputBy = By.Id("description");
        private static readonly By SuitePreconditionsInputBy = By.Id("preconditions");
        private static readonly By CreateSuiteButtonBy = By.CssSelector(".CCVJRT .u0i1tV .ZwgkIF");

        private static readonly By EllipsisEditBy = By.CssSelector("#layout .SmsctB .fa-ellipsis-h");
        private static readonly By EditButtonBy = By.CssSelector(".yxKHfs .Cr3S77 .fa-pencil");
        private static readonly By SuiteNameInputForClearBy = By.CssSelector(".tsnqft .XRXnTf");
        private static readonly By NameFieldClearBy = By.CssSelector(".tsnqft .XRXnTf");
        private static readonly By SuiteNameEditBy = By.Id("title");
        private static readonly By SuiteDescriptionEditBy = By.Id("description");
        private static readonly By SuitePreconditionsEditBy = By.Id("preconditions");
        private static readonly By SaveEditedSuiteButtonBy = By.CssSelector(".CCVJRT .u0i1tV .ZwgkIF");


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


        // Create Suite
        private void ClickToSuiteButton()
        {
            Driver.FindElement(SuiteButtonBy).Click();
        }

        private void SetSuiteName(string suiteName)
        {
            Driver.FindElement(SuiteNameInputBy).SendKeys(suiteName);
        }        

        private void SetSuiteDescriptione(string suiteDescription)
        {
            Driver.FindElement(SuiteDescriptionInputBy).SendKeys(suiteDescription);
        }
        private void SetSuitePreconditionse(string suitePreconditions)
        {
            Driver.FindElement(SuitePreconditionsInputBy).SendKeys(suitePreconditions);
        }

        private void ClickToCreateSuiteButton()
        {
            Driver.FindElement(CreateSuiteButtonBy).Click();
        }

        public ProjectTPPage CreateSuit(Suite suite)
        {
            ClickToSuiteButton();
            SetSuiteName(suite.Name);
            SetSuiteDescriptione(suite.Description);
            SetSuitePreconditionse(suite.Preconditions);            
            ClickToCreateSuiteButton();
            return this;
        }


        //Edit Suite
        private void ClickToEllipsis()
        {
            Driver.FindElement(EllipsisEditBy).Click();
        }

        private void ClickToEdit()
        {
            Driver.FindElement(EditButtonBy).Click();
        }

        private void ClickToClearNameField()
        {
            Driver.FindElement(SuiteNameInputForClearBy).Click();
        }

        private void ClearNameField()
        {
            Driver.FindElement(NameFieldClearBy).Clear();
        }

        private void EditSuiteName(string suiteName)
        {
            Driver.FindElement(SuiteNameEditBy).SendKeys(suiteName);
        }

        private void EditSuiteDescriptione(string suiteDescription)
        {
            Driver.FindElement(SuiteDescriptionEditBy).SendKeys(suiteDescription);
        }
        private void EditSuitePreconditionse(string suitePreconditions)
        {
            Driver.FindElement(SuitePreconditionsEditBy).SendKeys(suitePreconditions);
        }

        private void ClickToSaveEditButton()
        {
            Driver.FindElement(SaveEditedSuiteButtonBy).Click();
        }

        public ProjectTPPage EditSuit(Suite suite)
        {
            ClickToEllipsis();
            ClickToEdit();
            ClickToClearNameField();
            ClearNameField();
            EditSuiteName(suite.Name);
            EditSuiteDescriptione(suite.Description);
            EditSuitePreconditionse(suite.Preconditions);
            ClickToSaveEditButton();
            return this;
        }

    }
}
