using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class CreateItemRequest : IValidatable
    {
        public CreateItemRequest() { }

        public CreateItemRequest(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Notes = item.Notes;
            Price = item.Price;
            Quantity = item.Quantity;
            MinQuantity = item.MinQuantity;
            Type = item.Type;
            ParentId = item.ParentId;
            SortlyId = item.SortlyId;
            LabelUrl = item.LabelUrl;
            LabelUrlType = item.LabelUrlType;
            LabelUrlExtra = item.LabelUrlExtra;
            LabelUrlExtraType = item.LabelUrlExtraType;
            TagNames = item.TagNames;
            CustomAttributeValues = item.CustomAttributeValues;
            PhotoIds = item.Photos?.Select(x => x.Id)?.ToArray();
            MeasuredQuantity = item.MeasuredQuantity;
            OptionValueIds = item.OptionValueIds;
            ItemGroupId = item.ItemGroupId;
        }

        /// <summary>
        /// ID of the instance
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Name of item
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Item notes
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Price of an item
        /// </summary>
        [JsonPropertyName("price")]
        public string Price { get; set; }

        /// <summary>
        /// Quantity of an item
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Minimal quantity of an item
        /// </summary>
        [JsonPropertyName("min_quantity")]
        public int? MinQuantity { get; set; }

        /// <summary>
        /// Type of item ( folder | item )
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// ID of parent folder
        /// </summary>
        [JsonPropertyName("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Sortly system ID of the item
        /// </summary>
        [JsonPropertyName("sid")]
        public string SortlyId { get; set; }

        /// <summary>
        /// QR url OR barcode value
        /// </summary>
        [JsonPropertyName("label_url")]
        public string LabelUrl { get; set; }

        /// <summary>
        /// QR OR barcode type.
        /// </summary>
        [JsonPropertyName("label_url_type")]
        public string LabelUrlType { get; set; }

        /// <summary>
        /// QR url OR barcode value
        /// </summary>
        [JsonPropertyName("label_url_extra")]
        public string LabelUrlExtra { get; set; }

        /// <summary>
        /// QR OR barcode type.
        /// </summary>
        [JsonPropertyName("label_url_extra_type")]
        public string LabelUrlExtraType { get; set; }

        /// <summary>
        /// List of Item tags' names
        /// </summary>
        [JsonPropertyName("tag")]
        public string[] TagNames { get; set; }

        /// <summary>
        /// List of Custom Fields
        /// </summary>
        [JsonPropertyName("custom_attribute_values")]
        public CustomAttribute[] CustomAttributeValues { get; set; }

        /// <summary>
        /// Could be one of:
        /// 
        /// Directory path, url, base64 content
        /// </summary>
        [JsonPropertyName("photos")]
        public string[] Photos { get; set; }

        /// <summary>
        /// List of photo ids
        /// </summary>
        [JsonPropertyName("photo_ids")]
        public int[] PhotoIds { get; set; }

        [JsonPropertyName("measured_quantity")]
        public MeasuredQuantity MeasuredQuantity { get; set; }

        /// <summary>
        /// ID of option of attribute in Item Variant Group for Item. Required if populated item_group_id.
        /// </summary>
        [JsonPropertyName("option_value_ids")]
        public Guid[] OptionValueIds { get; set; }

        /// <summary>
        /// ID Item Variant Group for Item. Required if populated option_value_ids.
        /// </summary>
        [JsonPropertyName("item_group_id")]
        public Guid? ItemGroupId { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new SortlyValidationException("Name is required");

            if (string.IsNullOrEmpty(Type))
                throw new SortlyValidationException("Type is required");

            if (ItemGroupId != null && (OptionValueIds == null || OptionValueIds?.Length == 0))
                throw new SortlyValidationException("Item group id is defined but there are no option value ids included");

            if (ItemGroupId == null && OptionValueIds?.Length > 0)
                throw new SortlyValidationException("Option value ids are defined but there is no item group id set");
        }
    }
}
