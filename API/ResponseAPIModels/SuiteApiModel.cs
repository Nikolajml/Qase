using Allure.Commons;

namespace API.ResponseAPIModels
{
    public class SuiteResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string preconditions { get; set; }
        public int position { get; set; }
        public int cases_count { get; set; }
        //[JsonProperty("parent_id")] public int parent_id { get; set; }        
        //public DateTime created { get; set; }
        //public DateTime updated { get; set; }
        //public DateTime created_at { get; set; }
        //public DateTime updated_at { get; set; }

        public new string ToString()
        {
            return $"id: {id}, title: {title}, description: {description}";
        }
    }

    public class SuiteApiModel
    {
        public bool Status { get; set; }
        public SuiteResult Result { get; set; }

        public new string ToString()
        {
            return $"Status: {Status}";
        }
    }
}
