using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.UI
{
    public class SuiteEditTest : CommonBaseTest
    {
        public ProjectTPStepsPage _projectTPStepsPage;
        public SuiteStep _suiteStep;

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            _suiteStep = new SuiteStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.CheckThatPageIsOpen();
        }

        [SetUp]
        public void SetUp()
        {
            Suite suite = new SuiteBuilder()
               .SetSuiteName("New Mix Case UI test")
               .SetSuiteCode("TP")
               .Build();

            _suiteStep.CreateTestSuite(suite);
        }

        [Test]
        [Description("Successful UI test to edit a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void EditSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName("Edited Suite")
                .Build();

            _projectTPStepsPage.NavigateToEditSuite();
            _suiteStep.EditSuit_UI(suite);

            Assert.That(_projectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _suiteStep.DeleteSuite_UI();
        }
    }
}
