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
    public  class CaseStepsPage : BaseStep
    {
        public CaseStepsPage(IWebDriver driver) : base(driver)
        {

        }

        public void CreateCase(Case Case)
        {
            ProjectTPPage.ClickToEllipsis();
            ProjectTPPage.ClickToCaseButton();
            ProjectTPPage.WaitInputNameFieldCreateCase();
            ProjectTPPage.SetCaseName(Case.Title);
            ProjectTPPage.ClickToSaveCaseButton();                        
        }

        public void EditCase(Case Case)
        {
            ProjectTPPage.ClickToCaseTitle();
            ProjectTPPage.WaitCaseEditButton();            
            ProjectTPPage.ClickToCaseEdit();            
            ProjectTPPage.WaitCaseNameInputField();
            ProjectTPPage.ClickToCaseTitleField();
            ProjectTPPage.ClearCaseTitleField();
            ProjectTPPage.SetEditedCaseName(Case.Title);
            ProjectTPPage.ClickToSaveCaseButton();
        }
    }
}
