﻿using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.API;
using UI.Models;
using UI.Pages;

namespace Tests.UI
{
    public class DefectCreateTest : BaseTest
    {
        Defect defect;
        public DefectsTPPage DefectsTPPage;
        public DefectStep _defectStep;

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            _defectStep = new DefectStep(Driver, _apiClient);
            DefectsTPPage = new DefectsTPPage(Driver);
        }

        [Test]
        [Description("Successful UI test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateDefectTest()
        {     
            defect = new DefectBuilder()
                .SetDefectTitle(Faker.Name.FullName())
                .SetActualResult(Faker.Vehicle.Model())
                .Build();

            _defectStep.NavigateToDefectPage_UI();
            _defectStep.CheckThatDefectPageIsOpen();
            _defectStep.CreateDefect_UI(defect);
            Assert.That(_defectStep.DefectTitleForFirstAssert_UI, Is.EqualTo(defect.DefectTitle), "Defect title doesn't match expected result");

            _defectStep.NavigateToCreatedDefectForSecondAssert_UI();
            Assert.That(_defectStep.DefectDescriptionForSecondAssert_UI, Is.EqualTo(defect.ActualResult), "Defect description doesn't match expected result");
        }

        [TearDown]
        public void EditTearDown()
        {
            _defectStep.NavigateToDefectPage_UI();
            _defectStep.DeleteDefect_UI();
        }
    }
}