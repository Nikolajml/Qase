﻿using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using UI.Pages;

namespace Tests.UI
{
    public class DefectEditTest : BaseTest
    {
        Defect defect;        
        public DefectStep _defectStep;        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _defectStep = new DefectStep(Driver, _apiClient);
            
        }

        [SetUp]
        public void Setup()
        {
            defect = new Defect()
            {
                Code = "TP",
                DefectTitle = "Defect for update",
                ActualResult = "Result",
                Severity = 2
            };


            _defectStep.CreateTestDefect_API(defect);
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditDefectTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle(Faker.Name.FullName())
                .SetActualResult(Faker.Vehicle.Model())
                .Build();                        

            _defectStep.NavigateToDefectPage_UI();
            _defectStep.CheckThatDefectPageIsOpen();
            _defectStep.EditDefect_UI(defect);
            Assert.That(_defectStep.DefectTitleForFirstAssert_UI, Is.EqualTo(defect.DefectTitle), "Defect title doesn't match expected result");

            _defectStep.NavigateToCreatedDefectForSecondAssert_UI();
            Assert.That(_defectStep.DefectDescriptionForSecondAssert_UI(), Is.EqualTo(defect.ActualResult), "Defect description doesn't match expected result");
        }

        [TearDown]
        public void EditTearDown()
        {
            _defectStep.NavigateToDefectPage_UI();
            _defectStep.DeleteDefect_UI();
        }
    }
}