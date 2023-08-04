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
        private static readonly By SuiteTitleBy = By.ClassName("UdIne8");


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


        // Get Suite Title
        public string GetSuiteTitle()
        {
            return Driver.FindElement(SuiteTitleBy).Text;
        }
    }
}
