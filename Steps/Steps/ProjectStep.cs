using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace Steps.Steps
{
    public class ProjectStep
    {
        protected ApiClient _apiClient;
        protected Logger _logger;

        public ProjectStep(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ProjectApiModel CreateTestProject(Project project)
        {
            var request = new RestRequest(Endpoints.CREATE_PROJECT, Method.Post)
                .AddBody(project);

            _logger.Info("Create test project " + project.ToString());

            return _apiClient.Execute<ProjectApiModel>(request);
        }                

        public ProjectApiModel DeleteTestProject(Project project)
        {
            var request = new RestRequest(Endpoints.DELETE_PROJECT, Method.Delete)
                .AddUrlSegment("code", project.Code)
                .AddBody(project);

            return _apiClient.Execute<ProjectApiModel>(request);
        }
    }
}
