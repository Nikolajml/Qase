﻿using Core.Core;
using NUnit.Allure.Attributes;
using Steps.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tests.UI;
using UI.Models;

namespace Tests.MixTests
{
    public class PlanMixTest : CommonBaseTest
    {
        Plan plan { get; set; }
        Case Case { get; set; }

        public List<Plan> PlansForDelete = new List<Plan>();
        public List<Case> CasesForDelete = new List<Case>();

        protected CaseStep _caseStep;
        protected PlanStep _planStep;
        public NavigationSteps NavigationSteps;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _caseStep = new CaseStep(logger, Driver, _apiClient);
            _planStep = new PlanStep(logger, Driver, _apiClient);
            NavigationSteps = new NavigationSteps(logger, Driver);

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(config.Admin);
            Assert.IsTrue(NavigationSteps.IsPageOpened());
        }

        [SetUp]
        public void SetUp()
        {  
            Case = new Case()
            {
                Code = "TP",
                Title = "Case for Plan Mix Test"
            };

            var createdTestCase = _caseStep.CreateTestCase_API(Case);

            Case.Id = createdTestCase.Result.id.ToString();
            int CaseIdForPlan = int.Parse(Case.Id);
            Console.WriteLine(CaseIdForPlan);

            CasesForDelete.Add(Case);

            plan = new Plan()
            {
                Code = "TP",
                Title = "New Defect MIX",
                Cases = new List<int> { CaseIdForPlan }
            };

            var createdTestPlan = _planStep.CreateTestPlan_API(plan);

            plan.Id = createdTestPlan.Result.id.ToString();
            Console.WriteLine(plan.Id);

            PlansForDelete.Add(plan);
        }


        [Test]
        [Description("Edit Plan via UI after created and delete plan via API")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("Mix")]
        public void EditPlanMixTest()
        {
            plan.Title = "Edited Mix Plan Mix Test";
            plan.Description = "Edited Description";

            _planStep.NavigateToPlanPage();
            _planStep.EditPlan(plan);

            Assert.That(_planStep.CreatedPlanTitleForFirstAssert(), Is.EqualTo(plan.Title), "Edited plan Title didn't match");                        
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var testPlan in PlansForDelete)
            {
                _planStep.DeleteTestPlan_API(testPlan);
            }

            foreach (var testCasen in CasesForDelete)
            {
                _caseStep.DeleteTestCase_API(testCasen);
            }
        }
    }
}
