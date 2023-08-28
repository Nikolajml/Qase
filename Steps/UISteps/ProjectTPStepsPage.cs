using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using UI.Pages;

namespace Steps.UISteps
{
    public class ProjectTPStepsPage
    {
        public ProjectTPPage ProjectTPPage => new ProjectTPPage(Driver);
        protected IWebDriver Driver;

        public ProjectTPStepsPage(IWebDriver driver)
        {
            Driver = driver;
        }


        // Steps for Case
        public void NavigateToCreateCase()
        {
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToEllipsis();
            ProjectTPPage.ClickToCaseButton();            
        }

        public void NavigateToEditCase()
        {
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToCaseTitle();
            ProjectTPPage.ClickToCaseEdit();
        }

        public string CreatedCaseTitleForAssert()
        {
            return ProjectTPPage.GetCreatedCaseTitle();
        }


        // Steps for Suite

        public void NavigateToCreateSuite()
        {            
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToSuiteButton();
        }

        public void NavigateToEditSuite()
        {
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToEllipsis();
            ProjectTPPage.ClickToEdit();            
        }

        public string CreatedSuiteNameForAssert(string text)
        {
            return ProjectTPPage.GetSuiteNameByText(text);
        }



    }
}
