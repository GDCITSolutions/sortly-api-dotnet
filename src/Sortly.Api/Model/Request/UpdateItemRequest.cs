using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class UpdateItemRequest : IValidatable
    {
        public UpdateItemRequest() { }

        public UpdateItemRequest(Item item) 
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

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

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

        [JsonPropertyName("tags")]
        public string[] TagNames { get; set; }

        [JsonPropertyName("custom_attribute_values")]
        public CustomAttribute[] CustomAttributeValues { get; set; }

        [JsonPropertyName("photo_ids")]
        public int[] PhotoIds { get; set; }

        [JsonPropertyName("photos")]
        public string[] Photos { get; set; }

        [JsonPropertyName("measured_quantity")]
        public MeasuredQuantity MeasuredQuantity { get; set; }

        [JsonPropertyName("option_value_ids")]
        public Guid[] OptionValueIds { get; set; }

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
