using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class UnitOfMeasure
    {
        [JsonPropertyName("pretty_name")]
        public string PrettyName { get; set; }

        [JsonPropertyName("pretty_unit")]
        public string PrettyUnit { get; set; }

        [JsonPropertyName("scale")]
        public int Scale { get; set; }

        [JsonPropertyName("unit_name")]
        public string UnitName { get; set; }

        [JsonPropertyName("unit_type")]
        public string UnitType { get; set; }
    }
}
