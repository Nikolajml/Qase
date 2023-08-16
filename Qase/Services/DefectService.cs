using Qase.Client;
using Qase.Models;
using Qase.ResponseAPIModels;
using Qase.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Services
{
    public class DefectService : BaseService
    {
        public DefectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public DefectApiModel GetDefect(Defect defect, string id)
        {
            var request = new RestRequest(Endpoints.GET_DEFECT)
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
                .AddHeader("accept", "application/json")
                .AddHeader("Token", "2e4eae09e9a329ebea38ef86fbb0e98cd810cee178e4bfea3b9e4dca28a71e86")
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
