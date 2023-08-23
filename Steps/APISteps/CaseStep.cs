using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using UI.Models;

namespace Steps.APISteps
{
    public class CaseStep : CaseService
    {
        public CaseStep(ApiClient apiClient) : base(apiClient)
        {
        }

        public CaseApiModel CreateTestCase(Case Case)
        {
            var response = CreateCase(Case);

            return response;

        }

        public CaseApiModel GetTestCase(Case Case)
        {
            var response = GetCase(Case);

            _logger.Info("Case: " + response.ToString());                        

            return response;
        }

        public CaseApiModel UpdateTestCase(Case testCase)
        {
            var response = UpdateCase(testCase);

            _logger.Info("Case: " + response.ToString());

            
            return response;

        }

        public CaseApiModel DeleteTestCase(Case Case)
        {
            var response = DeleteCase(Case);

            _logger.Info("Case: " + response.ToString());                        

            return response;

        }

    }
}
