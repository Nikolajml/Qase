using NUnit.Allure.Attributes;
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
        public DefectsTPPage DefectsTPPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _defectStep = new DefectStep(Driver, _apiClient);
            DefectsTPPage = new DefectsTPPage(Driver);
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


            _defectStep.CreateTestDefect(defect);
        }

        [Test]
        [Description("Successful UI test to edit a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditCaseTest()
        {
            Defect defect = new DefectBuilder()
                .SetDefectTitle(Faker.Name.FullName())
                .SetActualResult(Faker.Vehicle.Model())
                .Build();                        

            _defectStep.NavigateToDefectPage();
            _defectStep.EditDefect(defect);
            Assert.That(_defectStep.DefectTitleForFirstAssert, Is.EqualTo(defect.DefectTitle), "Defect title doesn't match expected result");

            _defectStep.NavigateToCreatedDefectForSecondAssert();
            Assert.That(_defectStep.DefectDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult), "Defect description doesn't match expected result");
        }

        [TearDown]
        public void EditTearDown()
        {
            _defectStep.NavigateToDefectPage();
            _defectStep.DeleteDefect();
        }
    }
}
