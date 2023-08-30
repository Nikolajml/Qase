using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using Steps.UISteps;
using UI.Models;
using static API.ResponseAPIModels.GetAllTestCase;

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
        
         public List<CaseResult> GetAllTestCase(string code)
        {
            var response = GetAllCase(code);

            _logger.Info("Case: " + response.ToString());

            return response.Result.entities;
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

        public void DeleteTestCaseByName(string name, string code)
        {
            var list = GetAllTestCase(code);
                        
            var testCases = list.Where(testCase => testCase.title.Equals(name));

            foreach(var testCase in testCases)
            {
                var testCaseForDelte = new Case
                {
                    Id = testCase.id.ToString(),
                    Code = code,
                };

                DeleteTestCase(testCaseForDelte);
            }
          
        }

    }
}
