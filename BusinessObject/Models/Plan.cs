using System.Text.Json.Serialization;

namespace UI.Models
{
    public class Plan
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("cases")] public List<int> Cases { get; set; }

        public new string ToString()
        {
            return $"Title: {Title}, Description: {Description}";
        }
    }
}
