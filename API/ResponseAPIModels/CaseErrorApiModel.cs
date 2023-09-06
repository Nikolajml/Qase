using System.Text.Json.Serialization;

namespace Steps.Steps
{
    public class CaseErrorApiModel
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        
    }
}