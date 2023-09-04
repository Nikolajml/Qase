using UI.Models;
using API.ResponseAPIModels;
using Core.Client;
using Core.Utilities;
using RestSharp;

//namespace API.Services
//{
//    //public class DefectService
//    //{
//    //    //public DefectService(ApiClient apiClient) : base(apiClient)
//    //    //{

//    //    //}

//    //    //public DefectApiModel GetDefect(Defect defect)
//    //    //{
//    //    //    var request = new RestRequest(Endpoints.GET_DEFECT)
//    //    //        .AddUrlSegment("code", defect.Code)
//    //    //        .AddUrlSegment("id", defect.Id)                
//    //    //        .AddBody(defect);

//    //    //    return _apiClient.Execute<DefectApiModel>(request);
//    //    //}

//    //    //public DefectApiModel CreateDefect(Defect defect)
//    //    //{
//    //    //    var request = new RestRequest(Endpoints.CREATE_DEFECT, Method.Post)
//    //    //        .AddUrlSegment("code", defect.Code)                
//    //    //        .AddBody(defect);

//    //    //    return _apiClient.Execute<DefectApiModel>(request);
//    //    //}

//    //    //public DefectApiModel UpdateDefect(Defect defect)
//    //    //{
//    //    //    var request = new RestRequest(Endpoints.UPDATE_DEFECT, Method.Patch)
//    //    //        .AddUrlSegment("code", defect.Code)
//    //    //        .AddUrlSegment("id", defect.Id)                
//    //    //        .AddBody(defect);

//    //    //    return _apiClient.Execute<DefectApiModel>(request);
//    //    //}

//    //    //public DefectApiModel DeleteDefect(Defect defect)
//    //    //{
//    //    //    var request = new RestRequest(Endpoints.DELETE_DEFECT, Method.Delete)
//    //    //        .AddUrlSegment("code", defect.Code)
//    //    //        .AddUrlSegment("id", defect.Id)                
//    //    //        .AddBody(defect);

//    //    //    return _apiClient.Execute<DefectApiModel>(request);
//    //    //}
//    //}
//}
