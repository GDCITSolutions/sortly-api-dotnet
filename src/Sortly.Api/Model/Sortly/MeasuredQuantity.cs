using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class MeasuredQuantity
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("scale")]
        public int Scale { get; set; }
    }
}
