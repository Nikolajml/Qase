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
               
        [Test]
        public void CreateProjectTest()
        {           
            var expectedProject = new Project();
            expectedProject.Title = "MyProject";
            expectedProject.Code = "DH";            

            _logger.Info("Expected Project: " + expectedProject);

            var actualProject = _projectService.CreateProject(expectedProject);
                        
            Console.WriteLine($"Project Code: {actualProject.Code}");
            Console.WriteLine($"Project Name: {actualProject.Title}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedProject.Title, actualProject.Title);
                Assert.AreEqual(expectedProject.Code, actualProject.Code);
            });
        }

        [Test]
        public void GetProjectTest()
        {            
            var project = _projectService.GetProject("TP");
            _logger.Info(project.Title);

            Console.WriteLine($"Project Code: {project.Code}");
            Console.WriteLine($"Project Name: {project.Title}");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(project.Title, project.Title);
                Assert.AreEqual(project.Code, project.Code);
            });
                        
        }

        
    }
}
