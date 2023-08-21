using NLog;
using NUnit.Allure.Attributes;
using Qase.Models;
using Qase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.API
{
    public  class CaseApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Id { get; set; }

        [Test, Order(1)]
        [Description("Successful API test to create a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void CreateCaseTest()
        {   
            var caseRequest = new Case();
            caseRequest.Code = "OE";
            caseRequest.Title = "Case_api_New";

            var caseResponse = _caseService.CreateCase(caseRequest);                       
            
            Console.WriteLine($"Case Status: {caseResponse.status}"); 
            Console.WriteLine($"Case Id: {caseResponse.result.id}");

            Id = caseResponse.result.id.ToString();                       

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Id, caseResponse.result.id.ToString());
            });
        }

        [Test, Order(2)]
        [Description("Successful API test to get a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]

        public void GetCaseTest()
        {
            var caseRequest = new Case();
            caseRequest.Code = "OE";            

            var caseResponse = _caseService.GetCase(caseRequest, Id);
            _logger.Info("Case: " + caseResponse.ToString);

            Console.WriteLine($"Case Status: {caseResponse.status}");
            Console.WriteLine($"Case Id: {caseResponse.result.id}");                      

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Id, caseResponse.result.id.ToString());
            });
        }

        [Test, Order(3)]
        [Description("Successful API test to update a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void UpdateCaseTest()
        {
            var caseRequest = new Case();
            caseRequest.Code = "OE";
            caseRequest.Title = "New Update API";
            caseRequest.Description = "New Description API";

            var caseResponse = _caseService.UpdateCase(caseRequest, Id);

            Console.WriteLine($"Case Status: {caseResponse.status}");
            Console.WriteLine($"Case Id: {caseResponse.result.id}");                        

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Id, caseResponse.result.id.ToString());
            });
        }

        [Test, Order(4)]
        [Description("Successful test to delete a Case")]
        [AllureOwner("User")]
        [AllureTag("Smoke")]
        public void DeleteCaseTest()
        {
            var caseRequest = new Case();
            caseRequest.Code = "OE";

            var caseResponse = _caseService.DeleteSuite(caseRequest, Id);
            _logger.Info("Case: " + caseResponse.ToString);

            Console.WriteLine($"Case Status: {caseResponse.status}");
            Console.WriteLine($"Case Id: {caseResponse.result.id}");
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, caseResponse.status);
                Assert.AreEqual(Id, caseResponse.result.id.ToString());
            });
        }
    }
}
