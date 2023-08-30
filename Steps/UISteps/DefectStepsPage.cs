using UI.Models;
using UI.Pages;
using OpenQA.Selenium;

namespace Steps.UISteps
{
    public class DefectStepsPage
    {                       
        public DefectsTPPage DefectsTPPage => new DefectsTPPage(Driver);
        protected IWebDriver Driver;

        public DefectStepsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CreateDefect(Defect defect)
        {
            DefectsTPPage.OpenPage();
            DefectsTPPage.IsPageOpened();
            DefectsTPPage.ClickToCreateNewDefectButton();
            DefectsTPPage.SetDefectTitle(defect.DefectTitle);
            DefectsTPPage.SetActualresult(defect.ActualResult);
            DefectsTPPage.ClickToCreateDefectButton();
        }

        public string DefectTitleForFirstAssert()
        {
            return DefectsTPPage.GetDefectTitle();
        }

        public void NavigateToCreatedDefectForSecondAssert()
        {
            DefectsTPPage.ClickToDefectTitleToSecondAssert();
        }

        public string DefectTitleForSecondAssert()
        {
            return DefectsTPPage.GetDefectTitleForSecondAssert();
        }

        public string DefectDescriptionForSecondAssert()
        {
            return DefectsTPPage.GetDefectDescriptionForSecondAssert();
        }
        
        public void NavigateToDefectCase()
        {
            DefectsTPPage.OpenPage();
            DefectsTPPage.IsPageOpened();
        }

        public void EditDefect(Defect defect)
        {            
            DefectsTPPage.ClickToDefectTitle();
            DefectsTPPage.ClickToDefectEdit();
            DefectsTPPage.ClickToClearTitleDefectField();
            DefectsTPPage.ClearTitleDefectField();
            DefectsTPPage.SetEditedDefectTitle(defect.DefectTitle);
            DefectsTPPage.ClickToClearActualResult();
            DefectsTPPage.ClearActualResultField();
            DefectsTPPage.SetEditedActualResult(defect.ActualResult);
            DefectsTPPage.ClickToUpdateDefectButton();
        }
    }
}
