using Newtonsoft.Json.Linq;
using NLog;
using Qase.Models;
using Qase.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Tests.API
{
    public class ProjectApiTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Code { get; set; }

        [Test, Order(1)]
        public void CreateProjectTest()
        {           
            var projectRequest = new Project();
            projectRequest.Title = "Project API";
            projectRequest.Code = "PR";
            projectRequest.Access = "all";

            _logger.Info("Expected Project: " + projectRequest);

            var projectResponse = _projectService.CreateProject(projectRequest);
                        
            Console.WriteLine($"Project Code: {projectResponse.status}");

            Code = projectResponse.result.code.ToString();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(true, projectResponse.status);
                Assert.AreEqual(projectRequest.Code, projectResponse.result.code);
            });
        }

        [Test, Order(2)]
        public void GetProjectTest()
        {            
            var project = _projectService.GetProject(Code);
            _logger.Info(project.result.code);

            Console.WriteLine($"Project Code: {project.status}");

            Assert.AreEqual(true, project.status);
        }       
    }
}
