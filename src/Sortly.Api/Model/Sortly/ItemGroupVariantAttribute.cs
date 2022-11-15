using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class ItemGroupVariantAttribute
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("parent_id")]
        public int? ParentId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity_attributes")]
        public QuantityAttribute QuantityAttributes { get; set; }

        [JsonPropertyName("min_quantity_attributes")]
        public QuantityAttribute MinQuantityAttributes { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
