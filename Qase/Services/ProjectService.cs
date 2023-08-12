using NLog;
using Qase.Client;
using Qase.Models;
using Qase.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Services
{
    public class ProjectService : BaseService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ProjectService(ApiClient apiClient) : base(apiClient)
        {
        }


        public RestResponse GetJProject(string code)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("code", code)
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86");

            return _apiClient.Execute(request);
        }

        public Project GetProject(string code)
        {            
            var request = new RestRequest(Endpoints.GET_PROJECT)                
                .AddUrlSegment("code", code)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86");

            _logger.Info("Request: " + request.Resource);

            return _apiClient.Execute<Project>(request);
        }


        public Project CreateProject(Project project)
        {
            var request = new RestRequest(Endpoints.CREATE_PROJECT, Method.Post)  
                .AddHeader("accept", "application/json")
                .AddHeader("content-Type", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(project);

            return _apiClient.Execute<Project>(request);            
        }
                
    }
}
