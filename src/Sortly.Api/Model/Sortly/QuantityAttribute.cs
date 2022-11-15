using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class QuantityAttribute
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unit_type")]
        public string UnitType { get; set; }

        [JsonPropertyName("unit_name")]
        public string UnitName { get; set; }
    }
}
