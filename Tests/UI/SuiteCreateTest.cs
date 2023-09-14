using Bogus;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Tests.UI
{
    public class SuiteCreateTest : CommonBaseTest
    {        
        public ProjectTPStepsPage _projectTPStepsPage;
        public SuiteStep _suiteStep;
        public NavigationSteps NavigationSteps;

        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            _suiteStep = new SuiteStep(logger, Driver);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            NavigationSteps.IsPageOpened();
        }

        [Test]
        [Description("Successful UI test to create a Suite")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("UI")]
        public void CreateSuiteTest()
        {
            Suite suite = new SuiteBuilder()
                .SetSuiteName(Faker.Name.FullName())
                .SetSuiteDescription(Faker.Vehicle.Model())
                .SetSuitePreconditions(Faker.Vehicle.Vin())
                .Build();

            _projectTPStepsPage.NavigateToCreateSuite();
            _suiteStep.CreateSuit(suite);

            Assert.That(_projectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name));
        }
                
        [OneTimeTearDown]
        public void TearDown()
        {
            _suiteStep.DeleteSuite_UI();
        }
    }
}
