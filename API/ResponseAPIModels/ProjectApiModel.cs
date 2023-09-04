namespace API.ResponseAPIModels
{
    public class ProjectResult
    {
        public string code { get; set; }
        public string title { get; set; }
    }

    public class ProjectApiModel
    {
        public bool status { get; set; }
        public ProjectResult result { get; set; }
    }
}
