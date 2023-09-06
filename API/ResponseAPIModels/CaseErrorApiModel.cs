using System.Text.Json.Serialization;

namespace Steps.Steps
{
    public class CaseErrorApiModel
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}