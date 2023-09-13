using Allure.Commons;
using AngleSharp.Dom;
using Bogus.DataSets;
using Core.Utilities.Configuration;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace API.ResponseAPIModels
{
    public class CaseResult
    {
        public int id { get; set; }
        public int position { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string preconditions { get; set; }
        public string postconditions { get; set; }
        public int severity { get; set; }
        public int priority { get; set; }
        public int type { get; set; }
        public int layer { get; set; }
        public int is_flaky { get; set; }
        public int behavior { get; set; }
        public int automation { get; set; }
        public int status { get; set; }
        public object milestone_id { get; set; }
        public object suite_id { get; set; }
        public List<object> links { get; set; }
        public List<object> custom_fields { get; set; }
        public List<object> attachments { get; set; }
        public object steps_type { get; set; }
        public List<object> steps { get; set; }
        public List<object> @params { get; set; }
        public int member_id { get; set; }
        public int author_id { get; set; }
        public List<object> tags { get; set; }
        public object deleted { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public new string ToString()
        {
            return $"id: {id}, title: {title}, status: {status}";
        }

    }

    public class CaseApiModel
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("result")]
        public CaseResult Result { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public new string ToString()
        {
            return $"status: {Status}";
        }
    }
}


