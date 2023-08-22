using Core.Client;

namespace API.Services
{
    public class BaseService
    {
        protected ApiClient _apiClient;

        public BaseService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }

}
