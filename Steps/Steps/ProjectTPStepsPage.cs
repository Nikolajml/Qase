﻿using OpenQA.Selenium;
using UI.Pages;

namespace Steps.Steps
{
    public class ProjectTPStepsPage
    {
        public ProjectTPPage ProjectTPPage;

        public ProjectTPStepsPage(IWebDriver driver)
        {
            ProjectTPPage = new ProjectTPPage(driver);
        }


        // Steps for Case
        public void NavigateToCreateCase()
        {
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            //ProjectTPPage.ClickToEllipsis();
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
