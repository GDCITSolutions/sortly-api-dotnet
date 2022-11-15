using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class ItemGroupAttributeOption
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("order")]
        public int? Order { get; set; }
    }
}
