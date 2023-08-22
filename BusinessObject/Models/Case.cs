using System.Text.Json.Serialization;

namespace UI.Models
{
    public class Case
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("suite_id")] public string Id { get; set; }
    }
}
