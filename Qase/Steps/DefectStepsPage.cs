using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Steps
{
    public class DefectStepsPage : BaseStep
    {
        public DefectStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public DefectsTPPage CreateDefect(Defect defect)
        {
            DefectsTPPage.ClickToCreateNewDefectButton();
            DefectsTPPage.WaitCreateDefect();
            DefectsTPPage.SetDefectTitle(defect.DefectTitle);
            DefectsTPPage.SetActualresult(defect.ActualResult);
            DefectsTPPage.ClickToCreateDefectButton();

            return DefectsTPPage;
        }

        public DefectsTPPage EditDefect(Defect defect)
        {
            DefectsTPPage.WaitDefect();
            DefectsTPPage.ClickToDefectTitle();
            DefectsTPPage.WaitDefectDescription();
            DefectsTPPage.ClickToDefectEdit();
            DefectsTPPage.WaitCreateDefect();
            DefectsTPPage.ClickToClearTitleDefectField();
            DefectsTPPage.ClearTitleDefectField();
            DefectsTPPage.SetEditedDefectTitle(defect.DefectTitle);
            DefectsTPPage.ClickToClearActualResult();
            DefectsTPPage.ClearActualResultField();
            DefectsTPPage.SetEditedActualResult(defect.ActualResult);
            DefectsTPPage.ClickToUpdateDefectButton();

            return DefectsTPPage;
        }
    }
}
