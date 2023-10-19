using UI.Models;
using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using RestSharp;
using NLog;

namespace API.Services
{
    public class DefectService
    {
        protected ApiClient _apiClient;
        protected ILogger _logger;

        public DefectService(ILogger logger, ApiClient apiClient)
        {
            _apiClient = apiClient;

            _logger = logger;
        }

        public DefectApiModel GetDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.GET_DEFECT)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel CreateDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.CREATE_DEFECT, Method.Post)
                .AddUrlSegment("code", defect.Code)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel UpdateDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.UPDATE_DEFECT, Method.Patch)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel DeleteDefect_API(Defect defect)
        {
            var request = new RestRequest(Endpoints.DELETE_DEFECT, Method.Delete)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", defect.Id)
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public GetAllTestDefect GetAllTestDefect_API(string code)
        {
            var request = new RestRequest(Endpoints.GET_ALL_DEFECT)
                 .AddUrlSegment("code", code)
                 .AddParameter("limit", 90);

            return _apiClient.Execute<GetAllTestDefect>(request);
        }
    }
}
