using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class ItemGroupVariant
    {
        [JsonPropertyName("option_value_ids")]
        public Guid[] OptionValueIds { get; set; }

        [JsonPropertyName("item_attributes")]
        public ItemGroupVariantAttribute[] ItemAttributes { get; set; }
    }
}
