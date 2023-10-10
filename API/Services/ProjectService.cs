using Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using API.ResponseAPIModels;
using Core.Utilities;
using RestSharp;
using UI.Models;

namespace API.Services
{
    public class ProjectService
    {
        protected ApiClient _apiClient;
        protected ILogger _logger;

        public ProjectService(ILogger logger, ApiClient apiClient)
        {
            _apiClient = apiClient;

            _logger = logger;
        }

        public ProjectApiModel CreateProject_API(Project project)
        {
            var request = new RestRequest(Endpoints.CREATE_PROJECT, Method.Post)
                .AddBody(project);

            _logger.Info("Create test project " + project.ToString());

            _logger.Debug("CreateTestProject_API");
            return _apiClient.Execute<ProjectApiModel>(request);
        }

        public ProjectApiModel DeleteProject_API(Project project)
        {
            var request = new RestRequest(Endpoints.DELETE_PROJECT, Method.Delete)
                .AddUrlSegment("code", project.Code)
                .AddBody(project);

            return _apiClient.Execute<ProjectApiModel>(request);
        }
    }
}
