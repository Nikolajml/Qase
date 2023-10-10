using System.Text.Json.Serialization;

namespace UI.Models
{
    public class Suite
    {
        [JsonPropertyName("title")] public string Name { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("preconditions")] public string Preconditions { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; }

        public new string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }
    }
}
