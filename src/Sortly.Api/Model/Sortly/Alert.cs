using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class Alert
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("item_id")]
        public int? ItemId { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("is_fired")]
        public bool? IsFired { get; set; }

        [JsonPropertyName("recipient_groups")]
        public string[] RecipientGroups { get; set; }

        [JsonPropertyName("threshold_interval")]
        public string ThresholdInterval { get; set; }

        [JsonPropertyName("threshold_method")]
        public string ThresholdMethod { get; set; }

        [JsonPropertyName("threshold_value")]
        public int ThresholdValue { get; set; }

        [JsonPropertyName("triggerable_id")]
        public int TriggerableId { get; set; }

        [JsonPropertyName("custom_attribute_id")]
        public int? CustomAttributeId { get; set; }

        [JsonPropertyName("triggerable_type")]
        public string TriggerableType { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
