using BusinessObject.Models;
using BusinessObject.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using RestSharp;

namespace BusinessObject.Services
{
    public class DefectService : BaseService
    {
        public DefectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public DefectApiModel GetDefect(Defect defect, string id)
        {
            var request = new RestRequest(Endpoints.GET_DEFECT)         // заменить на RestClient и вынести на уровень конструктора
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel CreateDefect(Defect defect)
        {
            var request = new RestRequest(Endpoints.CREATE_DEFECT, Method.Post)
                .AddUrlSegment("code", defect.Code)
                .AddHeader("accept", "application/json")                                                // вынести в ApiClient
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86") // вынести в ApiClient
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel UpdateDefect(Defect defect, string id)
        {
            var request = new RestRequest(Endpoints.UPDATE_DEFECT, Method.Patch)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }

        public DefectApiModel DeleteDefect(Defect defect, string id)
        {
            var request = new RestRequest(Endpoints.DELETE_DEFECT, Method.Delete)
                .AddUrlSegment("code", defect.Code)
                .AddUrlSegment("id", id)
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
                .AddBody(defect);

            return _apiClient.Execute<DefectApiModel>(request);
        }
    }
}
