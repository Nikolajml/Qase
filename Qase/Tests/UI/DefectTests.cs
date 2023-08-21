using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Models;
using Qase.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.UI
{
    public class DefectTests : BaseTest
    {
        [Test, Order(1)]
        [Description("Successful UI test to create a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreateDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Defect")
                .SetActualResult("New actual result")
                .Build();
                        
            DefectTPPage.OpenPage();
            DefectTPPage.IsPageOpened();
            DefectStepsPage.CreateDefect(defect);
            DefectTPPage.WaitDefect();

            Assert.That(DefectTPPage.GetDefectTitle, Is.EqualTo(defect.DefectTitle));
                        
            DefectTPPage.ClickToDefectTitleToSecondAssert();
            DefectTPPage.WaitDefectDescription();

            Assert.That(PlanTPPage.GetPlanDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult));
        }


        [Test, Order(2)]
        [Description("Successful UI test to edit a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void EditDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Edit Defect")
                .SetActualResult("Edit actual result")
                .Build();

            DefectTPPage.OpenPage();
            DefectTPPage.IsPageOpened();
            DefectStepsPage.EditDefect(defect);
            DefectTPPage.WaitDefect();

            Assert.That(DefectTPPage.GetDefectTitle, Is.EqualTo(defect.DefectTitle));

            DefectTPPage.ClickToDefectTitleToSecondAssert();
            DefectTPPage.WaitDefectDescription();

            Assert.That(PlanTPPage.GetPlanDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult));
        }
    }
}
