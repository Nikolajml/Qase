
using BusinessObject.Models;
using NLog;

namespace Tests.API
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
        public void DeleteProjectTest()
        {
            var projectRequest = new Project();
            projectRequest.Code = "PR";

            var projectResponse = _projectService.DeleteSuite(projectRequest);
            _logger.Info("Case: " + projectResponse.ToString());

            Console.WriteLine($"Case Status: {projectResponse.status}");

            Assert.AreEqual(true, projectResponse.status);
        }

    }
}
