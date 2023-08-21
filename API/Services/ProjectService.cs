using BusinessObject.Models;
using BusinessObject.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using NLog;
using RestSharp;

namespace BusinessObject.Services
{
    public class ProjectService : BaseService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ProjectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public ProjectApiModel GetProject(string code)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("code", code)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86");

            _logger.Info("Request: " + request.Resource);

            return _apiClient.Execute<ProjectApiModel>(request);
        }

        public ProjectApiModel CreateProject(Project project)
        {
            var request = new RestRequest(Endpoints.CREATE_PROJECT, Method.Post)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(project);

            return _apiClient.Execute<ProjectApiModel>(request);
        }

        public ProjectApiModel DeleteSuite(Project project)
        {
            var request = new RestRequest(Endpoints.DELETE_PROJECT, Method.Delete)
                .AddUrlSegment("code", project.Code)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(project);

            return _apiClient.Execute<ProjectApiModel>(request);
        }
    }
}
