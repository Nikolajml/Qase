using NLog;
using Qase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.API
{
    public class PlanApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Id { get; set; }

        [Test, Order(1)]
        public void CreatePlanTest()
        {   
            var planRequest = new Plan();
            planRequest.Code = "OE";
            planRequest.Title = "Plan_api";
            planRequest.Cases = new List <int> { 50};

            var planResponse = _planService.CreatePlan(planRequest);

            Id = planResponse.result.id.ToString();


            Console.WriteLine($"Case Status: {planResponse.status}");
            Console.WriteLine($"Case Id: {planResponse.result.id}");

            Assert.AreEqual(true, planResponse.status);
        }

        [Test, Order(2)]
        public void GetPlanTest()
        {
            var planRequest = new Plan();
            planRequest.Code = "OE";

            var planResponse = _planService.GetPlan(planRequest, Id);
            _logger.Info("Case: " + planResponse.ToString);

            Console.WriteLine($"Case Status: {planResponse.status}");
            Console.WriteLine($"Case Id: {planResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, planResponse.status);
                Assert.AreEqual(Id, planResponse.result.id.ToString());
            });
        }

        [Test, Order(3)]
        public void UpdatePlanTest()
        {
            var planRequest = new Plan();
            planRequest.Code = "OE";
            planRequest.Title = "Updated Plan Title API";
            planRequest.Description = "Updated Plan Description API";
            planRequest.Cases = new List<int> { 50 };

            var planResponse = _planService.UpdatePlan(planRequest, Id);

            Console.WriteLine($"Case Status: {planResponse.status}");
            Console.WriteLine($"Case Id: {planResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, planResponse.status);
                Assert.AreEqual(Id, planResponse.result.id.ToString());
            });
        }

        [Test, Order(4)]
        public void DeletePlanTest()
        {
            var planRequest = new Plan();
            planRequest.Code = "OE";

            var planResponse = _planService.DeletePlan(planRequest, Id);
            _logger.Info("Case: " + planResponse.ToString);

            Console.WriteLine($"Case Status: {planResponse.status}");
            Console.WriteLine($"Case Id: {planResponse.result.id}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, planResponse.status);
                Assert.AreEqual(Id, planResponse.result.id.ToString());
            });
        }
    }
}
