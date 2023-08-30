﻿using UI.Models;
using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using API.Services;
using API.ResponseAPIModels;

namespace Tests.API
{
    public class PlanApiTest : BaseApiTest
    {        
        public List<Case> CasesForDelete = new();
        public List<Plan> PlansForDelete = new();
        public Plan plan { get; set; }
        public Case Case { get; set; }
        int CaseId { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Case = new Case()
            {
                Code = "OE",
                Title = "Case for Plan Mix Test"
            };

            var createdTestCase = _caseStep.CreateCase(Case);

            Case.Id = createdTestCase.Result.id.ToString();
            int CaseIdForPlan = int.Parse(Case.Id);
            CaseId = CaseIdForPlan;
            Console.WriteLine(CaseIdForPlan);

            CasesForDelete.Add(Case);

            plan = new Plan()
            {
                Code = "OE",
                Title = "Plan Mix",
                Cases = new List<int> {CaseIdForPlan}
            };

            PlansForDelete.Add(plan);
        }


        [Test]
        [Description("Successful API test to create a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void CreatePlanTest()
        {    
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            plan.Id = createdTestPlan.Result.id.ToString();
            PlansForDelete.Add(plan);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(createdTestPlan.Status, "Status code: Plan didn't create");
                Assert.AreEqual(plan.Id, createdTestPlan.Result.id.ToString(), "Plan ID didn't match");
            });
        }               


        [Test]
        [Description("Successful API test to get a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void GetPlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            plan.Id = createdTestPlan.Result.id.ToString();
            PlansForDelete.Add(plan);

            var getedPlanCase = _planStep.GetTestPlan(plan);
            _logger.Info("Plan: " + getedPlanCase.ToString());                        

            Assert.Multiple(() =>
            {
                Assert.IsTrue(getedPlanCase.Status, "Status code: Plan didn't get");
                Assert.AreEqual(plan.Id, getedPlanCase.Result.id.ToString());
                Assert.AreEqual(plan.Title, getedPlanCase.Result.title.ToString(), "Plan ID didn't match");                
            });
        }
                

        [Test]
        [Description("Successful API test to update a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void UpdatePlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            plan.Id = createdTestPlan.Result.id.ToString();
            PlansForDelete.Add(plan);

            plan.Title = "Updated Plan Title API";
            plan.Description = "Updated Plan Description API";
            plan.Cases = new List<int> { CaseId };

            var updatedPlanCase = _planStep.UpdateTestPlan(plan);                        

            Assert.Multiple(() =>
            {
                Assert.IsTrue(updatedPlanCase.Status, "Status code: Plan didn't update");
                Assert.AreEqual(plan.Id, updatedPlanCase.Result.id.ToString(), "Plan ID didn't match");
            });
        }              


        [Test]
        [Description("Successful API test to delete a Plan")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        [Category("API")]
        public void DeletePlanTest()
        {
            var createdTestPlan = _planStep.CreateTestPlan(plan);
            plan.Id = createdTestPlan.Result.id.ToString();

            var planResponse = _planStep.DeleteTestPlan(plan);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(planResponse.Status, "Status code: Plan didn't delete");
                Assert.AreEqual(plan.Id, planResponse.Result.id.ToString(), "Plan ID didn't match");
            });
        }
                

        [OneTimeTearDown]
        public void TearDown()
        {
            foreach (var planForDelete in PlansForDelete)
            {
                _planStep.DeleteTestPlan(planForDelete);
            }
        }
    }
}
