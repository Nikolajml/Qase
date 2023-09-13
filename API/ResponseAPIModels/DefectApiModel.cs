namespace API.ResponseAPIModels
{
    public class DefectResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string actual_result { get; set; }
        public string status { get; set; }
        public object milestone_id { get; set; }
        public string severity { get; set; }
        public int member_id { get; set; }
        public int author_id { get; set; }
        public List<object> attachments { get; set; }
        public List<object> custom_fields { get; set; }
        public string external_data { get; set; }
        public object resolved_at { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<object> tags { get; set; }

        public new string ToString()
        {
            return $"id: {id}, title: {title}, status: {status}, severity: {severity}, actual result: {actual_result}";
        }
    }

    public class DefectApiModel
    {
        public bool Status { get; set; }
        public DefectResult Result { get; set; }

        public new string ToString()
        {
            return $"Status: {Status}";
        }
    }
}
