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

        [Test]
        public void CreatePlanTest()
        {            

            var expectedPlan = new Plan();
            expectedPlan.Code = "OE";
            expectedPlan.Title = "Plan_api";
            expectedPlan.Cases = 2;

            var actualPlan = _planService.CreatePlan(expectedPlan);


            //Console.WriteLine($"Suite Id: {actualPlan.Id}");
            Console.WriteLine($"Suite Code: {actualPlan.Code}");
            Console.WriteLine($"Suite Name: {actualPlan.Title}");



            //Assert.Multiple(() =>
            //{
            //    Assert.AreEqual(expectedSuite.Name, actualSuite.Name);
            //    Assert.AreEqual(expectedSuite.Code, actualSuite.Code);
            //});
        }
    }
}
