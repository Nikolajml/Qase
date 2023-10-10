using Allure.Commons;

namespace API.ResponseAPIModels
{
    public class ProjectResult
    {
        public string code { get; set; }
        public string title { get; set; }
    }

    public class ProjectApiModel
    {
        public bool Status { get; set; }
        public ProjectResult result { get; set; }

        public new string ToString()
        {
            return $"Status: {Status}";
        }
    }
}
