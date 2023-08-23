using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            _logger.Info("Case: " + response.ToString());

            return response;
        }

        public DefectApiModel UpdateTestDefect(Defect defect)
        {
            var response = UpdateDefect(defect);

            _logger.Info("Case: " + response.ToString());

            return response;

        }

        public DefectApiModel DeleteTestDefect(Defect defect)
        {
            var response = DeleteDefect(defect);

            _logger.Info("Case: " + response.ToString());

            return response;
        }
    }
}
