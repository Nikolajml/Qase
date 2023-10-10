using API.ResponseAPIModels;
using API.Services;
using Core.Client;
using UI.Models;

namespace Steps.Steps
{
    public class ProjectStep
    {
        protected ApiClient _apiClient;
        protected NLog.ILogger _logger;

        public ProjectService ProjectService;

        public ProjectStep(NLog.ILogger logger, ApiClient apiClient = null)
        {            

            if (apiClient != null)
            {
                _apiClient = apiClient;
            }

            if (apiClient != null)
            {
                ProjectService = new ProjectService(logger, apiClient);
            }

            _logger = logger;
        }
               

        public ProjectApiModel CreateTestProject_API(Project project)
        {
            var response = ProjectService.CreateProject_API(project);

            return response!;
        }

        public ProjectApiModel DeleteTestProject_API(Project project)
        {
            var response = ProjectService.DeleteProject_API(project);

            return response!;
        }
    }
}