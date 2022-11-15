using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class Tag
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
