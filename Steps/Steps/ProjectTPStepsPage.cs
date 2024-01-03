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
            _logger.Info("Navigate to create case");
            ProjectTPPage.OpenPage();
            ProjectTPPage.ClickToCaseButton();
        }

        public void NavigateToEditCase()
        {
            _logger.Info("Navigate to edit case");
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToCaseTitle();
            ProjectTPPage.ClickToCaseEdit();
        }

        public void NavigateToEditCase_MIX()
        {
            _logger.Info("Navigate to edit case for Mix Tests");
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
            _logger.Info("Navigate to create suite");
            ProjectTPPage.OpenPage();
            ProjectTPPage.IsPageOpened();
            ProjectTPPage.ClickToSuiteButton();
        }

        
        public void NavigateToEditSuite()
        {
            _logger.Info("Navigate to edit suite");
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
            _logger.Info("Navigate to defect page");
            ProjectTPPage.NavigateToDefectsPage();
        }

        // Steps for Plans

        public void NavigateToPlansPage()
        {
            _logger.Info("Navigate to plan page");
            ProjectTPPage.NavigateToPlansPage();
        }

        // Steps for Runs

        public void NavigateToRunPage()
        {
            _logger.Info("Navigate to plan page");
            ProjectTPPage.NavigateToRunsPage();
        }
    }
}
