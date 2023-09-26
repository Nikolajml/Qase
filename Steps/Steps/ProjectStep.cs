using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using NUnit.Framework.Internal;
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
        protected NLog.ILogger _logger;  

        public ProjectStep(NLog.ILogger logger, ApiClient apiClient)
        {
            _apiClient = apiClient;            
            _logger = logger;                   
        }

        public ProjectApiModel CreateTestProject_API(Project project)
        {
            var request = new RestRequest(Endpoints.CREATE_PROJECT, Method.Post)
                .AddBody(project);

            _logger.Info("Create test project " + project.ToString());

            _logger.Debug("CreateTestProject_API - 2");
            return _apiClient.Execute<ProjectApiModel>(request);
        }                

        public ProjectApiModel DeleteTestProject_API(Project project)
        {
            var request = new RestRequest(Endpoints.DELETE_PROJECT, Method.Delete)
                .AddUrlSegment("code", project.Code)
                .AddBody(project);

            return _apiClient.Execute<ProjectApiModel>(request);
        }
    }
}
