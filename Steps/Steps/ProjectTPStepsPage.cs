using NLog;
using OpenQA.Selenium;
using UI.Pages;

namespace Steps.Steps
{
    public class ProjectTPStepsPage
    {
        public ProjectTPPage ProjectTPPage;
        public ILogger _logger;

        public ProjectTPStepsPage(ILogger logger, IWebDriver driver)
        {
            ProjectTPPage = new ProjectTPPage(logger, driver);
            _logger = logger;
        }


        // Steps for Case
        public void NavigateToCreateCase()
        {
            ProjectTPPage.OpenPage();
            ProjectTPPage.ClickToCaseButton();
        }

        public void NavigateToEditCase()
        {
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToCaseTitle();
            ProjectTPPage.ClickToCaseEdit();
        }

        public void NavigateToEditCase_MIX()
        {            
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
        }

        public string CreatedSuiteNameForAssert(string text)
        {
            return ProjectTPPage.GetSuiteNameByText(text);
        }


        // Steps for Defects

        public void NavigateToDefectsPage()
        {
            ProjectTPPage.NavigateToDefectsPage();
        }
    }
}
