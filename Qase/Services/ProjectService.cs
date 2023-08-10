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
        public ProjectService(ApiClient apiClient) : base(apiClient)
        {
        }

        public Project GetProject(string code)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("code", code);                

            return _apiClient.Execute<Project>(request);
        }

        public Project CreateProject(Project project)
        {
            var request = new RestRequest(Endpoints.CREATE_PROJECT, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddBody(project);

            return _apiClient.Execute<Project>(request);
        }


        
    }
}
