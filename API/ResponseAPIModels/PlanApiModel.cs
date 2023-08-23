﻿namespace API.ResponseAPIModels
{
    public class Cases
    {
        public int case_id { get; set; }
        public object assignee_id { get; set; }
    }

    public class PlanResult
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int cases_count { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int average_time { get; set; }
        public List<Cases> cases { get; set; }
    }

    public class PlanApiModel
    {
        public bool Status { get; set; }
        public PlanResult Result { get; set; }
    }
}