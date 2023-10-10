using System.Text.Json.Serialization;

namespace UI.Models
{
    public class Defect
    {
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("title")] public string DefectTitle { get; set; }
        [JsonPropertyName("actual_result")] public string ActualResult { get; set; }
        [JsonPropertyName("severity")] public int Severity { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; }

        public new string ToString()
        {
            return $"DefectTitle: {DefectTitle}, ActualResult: {ActualResult}";
        }
    }
}
