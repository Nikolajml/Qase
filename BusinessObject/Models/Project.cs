using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public class Project
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("access")] public string Access { get; set; }
        [JsonPropertyName("group")] public string Group { get; set; }


    }
}
