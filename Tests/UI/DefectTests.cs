using UI.Models;
using NUnit.Allure.Attributes;
using Steps.Steps;
using Core.Client;

namespace Tests.UI
{
    public class DefectTests : BaseTest
    {
        //Defect defect;
        
        public DefectStep _defectStep;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _defectStep = new DefectStep(Driver);
            //_defectStep = new CaseStep(Driver, _apiClient);
        }




        [Test]
        [Description("Successful UI test to create a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateDefectTest()
        {
            //Defect defect = new DefectBuilder()
            //    .SetDefectTitle("Defect")
            //    .SetActualResult("New actual result")
            //.Build();

            //_defectStep.NavigateToDefectCase();
            //_defectStep.CreateDefect(defect);
            //Assert.That(_defectStep.DefectTitleForFirstAssert, Is.EqualTo(defect.DefectTitle), "DEFECT TITLE doesn't match expected result");

            //_defectStep.NavigateToCreatedDefectForSecondAssert();
            //Assert.That(_defectStep.DefectDescriptionForSecondAssert, Is.EqualTo(defect.ActualResult), "DEFECT DESCRIPTION doesn't match expected result"); // Errore message                       
        }


        [Test]
        [Description("Successful UI test to edit a Defect")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditDefectTest()
        {
            //Defect defect = new DefectBuilder()
            //    .SetDefectTitle("Edit Defect")
            //    .SetActualResult("Edit actual result")
            //    .Build();

            //_defectStep.NavigateToDefectPage();
            //_defectStep.EditDefect(defect);
            //Assert.That(_defectStep.DefectTitleForFirstAssert, Is.EqualTo(defect.DefectTitle), "DEFECT TITLE doesn't match expected result");

            //_defectStep.NavigateToCreatedDefectForSecondAssert();
            //Assert.That(_defectStep.DefectDescriptionForSecondAssert(), Is.EqualTo(defect.ActualResult), "DEFECT DESCRIPTION doesn't match expected result");
        }
    }
}
