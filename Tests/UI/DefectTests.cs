﻿using UI.Models;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    public class DefectTests : BaseTest
    {
        public List<Defect> DefectsForDelete = new();

        [Test]
        [Description("Successful UI test to create a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Defect")
                .SetActualResult("New actual result")
                .Build();                      

            DefectStep.NavigateToDefectCase();
            DefectStep.CreateDefect(defect);
            Assert.That(DefectStep.DefectTitleForFirstAssert, Is.EqualTo(defect.DefectTitle), "DEFECT TITLE doesn't match expected result");

            DefectStep.NavigateToCreatedDefectForSecondAssert();
            Assert.That(DefectStep.DefectDescriptionForSecondAssert, Is.EqualTo(defect.ActualResult), "DEFECT DESCRIPTION doesn't match expected result"); // Errore message                       
        }


        [Test]
        [Description("Successful UI test to edit a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle("Edit Defect")
                .SetActualResult("Edit actual result")
                .Build();

            DefectStep.NavigateToDefectCase();
            DefectStep.EditDefect(defect);
            Assert.That(DefectStep.DefectTitleForFirstAssert, Is.EqualTo(defect.DefectTitle), "DEFECT TITLE doesn't match expected result");

            DefectStep.NavigateToCreatedDefectForSecondAssert();
            Assert.That(DefectStep.DefectDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult), "DEFECT DESCRIPTION doesn't match expected result");
        }
    }
}
