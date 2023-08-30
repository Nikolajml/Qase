using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using UI.Models;

namespace Steps.APISteps
{
    public class DefectStep : DefectService
    {
        public DefectStep(ApiClient apiClient) : base(apiClient)
        {
        }

        public DefectApiModel CreateTestDefect(Defect defect)
        {
            var response = CreateDefect(defect);
                  
            return response;

        }

        public DefectApiModel GetTestDefect(Defect defect)
        {
            var response = GetDefect(defect);

            _logger.Info("Defect: " + response.ToString());

            return response;
        }

        public DefectApiModel UpdateTestDefect(Defect defect)
        {
            var response = UpdateDefect(defect);

            _logger.Info("Defect: " + response.ToString());

            return response;

        }

        public DefectApiModel DeleteTestDefect(Defect defect)
        {
            var response = DeleteDefect(defect);

            _logger.Info("Defect: " + response.ToString());

            return response;
        }
    }
}
