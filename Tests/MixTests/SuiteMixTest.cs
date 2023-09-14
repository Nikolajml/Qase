using Core.Client;
using Core.Core;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UI;
using UI.Models;

namespace Tests.MixTests
{
    public class SuiteMixTest : CommonBaseTest
    {
        Suite suite { get; set; }

        public List<Suite> SuitesForDelete = new List<Suite>();

        public SuiteStep _suiteStep;
        protected ProjectTPStepsPage _projectTPStepsPage;
        public NavigationSteps NavigationSteps;


        [OneTimeSetUp]
        public void OniTimeTtestSetUp()
        {
            _suiteStep = new SuiteStep(logger, Driver, _apiClient);
            _projectTPStepsPage = new ProjectTPStepsPage(logger, Driver);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            Assert.IsTrue(NavigationSteps.IsPageOpened());
        }

        [SetUp]
        public void SetUp()
        {
            suite = new SuiteBuilder()
               .SetSuiteName("New Mix Case UI test")
               .SetSuiteCode("TP")
               .Build();

            var createdTestSuite = _suiteStep.CreateTestSuite_API(suite);
            logger.Info("Created Suite: " + createdTestSuite.ToString());

            if (createdTestSuite.Status == false)
            {
                Assert.Inconclusive("Suite didn't create: " + createdTestSuite.ToString());
            }

            suite.Id = createdTestSuite.Result.id.ToString();
            logger.Info("Created Suite Id: " + createdTestSuite.Result.id.ToString());

            SuitesForDelete.Add(suite);
        }


        [Test]
        [Description("Creation and deletion Case via API. Editing Case via UI")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("MIX")]
        public void EditSuiteMixTest()
        {
            suite.Name = "Edited Mix Suite UI test";

            _projectTPStepsPage.NavigateToEditSuite();
            _suiteStep.EditSuit_UI(suite);

            Assert.That(_projectTPStepsPage.CreatedSuiteNameForAssert(suite.Name), Is.EqualTo(suite.Name), "Edited Suite Name didn't match");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var testSuite in SuitesForDelete)
            {
                _suiteStep.DeleteTestSuite_API(testSuite);
            }
        }
    }
}
