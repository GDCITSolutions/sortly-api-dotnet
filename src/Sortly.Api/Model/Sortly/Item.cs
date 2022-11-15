using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class Item
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Price of an item
        /// 
        /// Docs say its a decimal but its a string
        /// </summary>
        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("min_quantity")]
        public int? MinQuantity { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("parent_id")]
        public int? ParentId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonPropertyName("sid")]
        public string SortlyId { get; set; }

        [JsonPropertyName("label_url")]
        public string LabelUrl { get; set; }

        [JsonPropertyName("label_url_type")]
        public string LabelUrlType { get; set; }

        [JsonPropertyName("label_url_extra")]
        public string LabelUrlExtra { get; set; }

        [JsonPropertyName("label_url_extra_type")]
        public string LabelUrlExtraType { get; set; }

        [JsonPropertyName("tag_names")]
        public string[] TagNames { get; set; }

        [JsonPropertyName("tags")]
        public Tag[] Tags { get; set; }

        [JsonPropertyName("custom_attribute_values")]
        public CustomAttribute[] CustomAttributeValues { get; set; }

        [JsonPropertyName("photos")]
        public Photo[] Photos { get; set; }

        [JsonPropertyName("measured_quantity")]
        public MeasuredQuantity MeasuredQuantity { get; set; }

        [JsonPropertyName("option_value_ids")]
        public Guid[] OptionValueIds { get; set; }

        [JsonPropertyName("item_group_id")]
        public Guid? ItemGroupId { get; set; }
    }
}
