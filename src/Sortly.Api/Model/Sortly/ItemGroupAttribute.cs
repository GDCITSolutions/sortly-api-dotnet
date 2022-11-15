using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class ItemGroupAttribute
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("order")]
        public int? Order { get; set; }

        [JsonPropertyName("options")]
        public ItemGroupAttributeOption[] Options { get; set; }
    }
}
