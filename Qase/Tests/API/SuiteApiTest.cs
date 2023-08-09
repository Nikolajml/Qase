using Newtonsoft.Json.Linq;
using NLog;
using Qase.Models;
using Qase.Services;
using Qase.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.API
{
    public class SuiteApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        //public int Id { get; set; }
        //public string Code { get; set; }
                
        //public Suite expectedSuite = TestDataHelper.CreateSuite("CreateSuite.json");

        [Test]
        public void CreateSuiteTest()
        {
            //var actualSuite = _suiteService.CreateSuite(expectedSuite);

            var expectedSuite = new Suite();
            expectedSuite.Code = "55";
            expectedSuite.Name = "Test Project API";
            

            var actualSuite = _suiteService.CreateSuite(expectedSuite);

            Console.WriteLine($"Project Id: {actualSuite.Id}");
            Console.WriteLine($"Project Code: {actualSuite.Code}");
            Console.WriteLine($"Project Name: {actualSuite.Name}");



            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSuite.Name, actualSuite.Name);
                Assert.AreEqual(expectedSuite.Code, actualSuite.Code);
            });
        }
    }
}
