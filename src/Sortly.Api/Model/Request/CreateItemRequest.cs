using Sortly.Api.Common.Enums;
using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using Sortly.Api.Model.Sortly;
using System.IO.Abstractions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Request
{
    public class CreateItemRequest : IValidatable, IPhotoRequest
    {
        private const string JSON_NAME = "name";
        private const string JSON_TYPE = "type";
        private const string JSON_NOTES = "notes";
        private const string JSON_PRICE = "price";
        private const string JSON_QUANTITY = "quantity";
        private const string JSON_MIN_QUANTITY = "min_quantity";
        private const string JSON_PARENT_ID = "parent_id";
        private const string JSON_SORTLY_ID = "sid";
        private const string JSON_LABEL_URL = "label_url";
        private const string JSON_LABEL_URL_TYPE = "label_url_type";
        private const string JSON_LABEL_URL_EXTRA = "label_url_extra";
        private const string JSON_LABEL_URL_EXTRA_TYPE = "label_url_extra_type";
        private const string JSON_TAGS = "tags";
        private const string JSON_CUSTOM_ATTRIBUTE_VALUES = "custom_attribute_values";
        private const string JSON_PHOTOS = "photos";
        private const string JSON_PHOTO_IDS = "photo_ids";
        private const string JSON_MEASURED_QUANTITY = "measured_quantity";
        private const string JSON_OPTION_VALUE_IDS = "option_value_ids";
        private const string JSON_ITEM_GROUP_ID = "item_group_id";

        public CreateItemRequest() { }

        public CreateItemRequest(Item item)
        {
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
            Tags = item.TagNames;
            CustomAttributeValues = item.CustomAttributeValues;
            PhotoIds = item.Photos?.Select(x => x.Id)?.ToArray();
            MeasuredQuantity = item.MeasuredQuantity;
            OptionValueIds = item.OptionValueIds;
            ItemGroupId = item.ItemGroupId;
        }

        /// <summary>
        /// Name of item
        /// </summary>
        [JsonPropertyName(JSON_NAME)]
        public string Name { get; set; }

        [JsonPropertyName(JSON_SORTLY_ID)]
        public string SortlyId { get; set; }

        /// <summary>
        /// Item notes
        /// </summary>
        [JsonPropertyName(JSON_NOTES)]
        public string Notes { get; set; }

        /// <summary>
        /// Price of an item
        /// </summary>
        [JsonPropertyName(JSON_PRICE)]
        public string Price { get; set; }

        /// <summary>
        /// Quantity of an item
        /// </summary>
        [JsonPropertyName(JSON_QUANTITY)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Minimal quantity of an item
        /// </summary>
        [JsonPropertyName(JSON_MIN_QUANTITY)]
        public int? MinQuantity { get; set; }

        /// <summary>
        /// Type of item ( folder | item )
        /// </summary>
        [JsonPropertyName(JSON_TYPE)]
        public string Type { get; set; }

        /// <summary>
        /// ID of parent folder
        /// </summary>
        [JsonPropertyName(JSON_PARENT_ID)]
        public int? ParentId { get; set; }

        /// <summary>
        /// QR url OR barcode value
        /// </summary>
        [JsonPropertyName(JSON_LABEL_URL)]
        public string LabelUrl { get; set; }

        /// <summary>
        /// QR OR barcode type.
        /// </summary>
        [JsonPropertyName(JSON_LABEL_URL_TYPE)]
        public string LabelUrlType { get; set; }

        /// <summary>
        /// QR url OR barcode value
        /// </summary>
        [JsonPropertyName(JSON_LABEL_URL_EXTRA)]
        public string LabelUrlExtra { get; set; }

        /// <summary>
        /// QR OR barcode type.
        /// </summary>
        [JsonPropertyName(JSON_LABEL_URL_EXTRA_TYPE)]
        public string LabelUrlExtraType { get; set; }

        /// <summary>
        /// List of Item tags' names
        /// </summary>
        [JsonPropertyName(JSON_TAGS)]
        public string[] Tags { get; set; }

        /// <summary>
        /// List of Custom Fields
        /// </summary>
        [JsonPropertyName(JSON_CUSTOM_ATTRIBUTE_VALUES)]
        public CustomAttribute[] CustomAttributeValues { get; set; }

        /// <summary>
        /// Could be one of:
        /// 
        /// Directory path, url, base64 content
        /// </summary>
        [JsonPropertyName(JSON_PHOTOS)]
        public PhotoRequest[] Photos { get; set; }

        /// <summary>
        /// List of photo ids
        /// </summary>
        [JsonPropertyName(JSON_PHOTO_IDS)]
        public int[] PhotoIds { get; set; }

        [JsonPropertyName(JSON_MEASURED_QUANTITY)]
        public MeasuredQuantity MeasuredQuantity { get; set; }

        /// <summary>
        /// ID of option of attribute in Item Variant Group for Item. Required if populated item_group_id.
        /// </summary>
        [JsonPropertyName(JSON_OPTION_VALUE_IDS)]
        public Guid[] OptionValueIds { get; set; }

        /// <summary>
        /// ID Item Variant Group for Item. Required if populated option_value_ids.
        /// </summary>
        [JsonPropertyName(JSON_ITEM_GROUP_ID)]
        public Guid? ItemGroupId { get; set; }

        private void AddStringContent(MultipartFormDataContent form, string name, object value) 
        {
            if (value != null)
                form.Add(new StringContent(value.ToString(), Encoding.UTF8), name);
        }

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

            if (CustomAttributeValues?.Length > 0)
                foreach (var cav in CustomAttributeValues)
                    cav.Validate();
        }

        public HttpContent AsHttpPayload(IFileSystem fileSystem) 
        {
            if (!Photos?.Any(x => x.PhotoRequestType == PhotoRequestType.Path) ?? true)
                return new StringContent(JsonSerializer.Serialize(this), Encoding.UTF8, "application/json");

            var form = new MultipartFormDataContent();

            AddStringContent(form, JSON_NAME, Name);
            AddStringContent(form, JSON_TYPE, Type);
            AddStringContent(form, JSON_SORTLY_ID, SortlyId);
            AddStringContent(form, JSON_NOTES, Notes);
            AddStringContent(form, JSON_PRICE, Price);
            AddStringContent(form, JSON_QUANTITY, Quantity);
            AddStringContent(form, JSON_MIN_QUANTITY, MinQuantity);
            AddStringContent(form, JSON_PARENT_ID, ParentId);
            AddStringContent(form, JSON_LABEL_URL, LabelUrl);
            AddStringContent(form, JSON_LABEL_URL_TYPE, LabelUrlType);
            AddStringContent(form, JSON_LABEL_URL_EXTRA, LabelUrlExtra);
            AddStringContent(form, JSON_LABEL_URL_EXTRA_TYPE, LabelUrlExtraType);
            AddStringContent(form, JSON_LABEL_URL_EXTRA_TYPE, LabelUrlExtraType);
            AddStringContent(form, JSON_ITEM_GROUP_ID, ItemGroupId);

            if (MeasuredQuantity != null) 
            {
                AddStringContent(form, $"{JSON_MEASURED_QUANTITY}[name]", MeasuredQuantity.Name);
                AddStringContent(form, $"{JSON_MEASURED_QUANTITY}[scale]", MeasuredQuantity.Scale);
                AddStringContent(form, $"{JSON_MEASURED_QUANTITY}[value]", MeasuredQuantity.Value);
                AddStringContent(form, $"{JSON_MEASURED_QUANTITY}[type]", MeasuredQuantity.Type);
            }

            foreach (var t in (Tags ?? Enumerable.Empty<string>()))
                AddStringContent(form, $"{JSON_TAGS}[]", t.ToString());

            foreach (var t in (CustomAttributeValues ?? Enumerable.Empty<CustomAttribute>()))
            {
                AddStringContent(form, $"{JSON_CUSTOM_ATTRIBUTE_VALUES}[][value]", t.Value);
                AddStringContent(form, $"{JSON_CUSTOM_ATTRIBUTE_VALUES}[][attribute_value]", t.AttributeValue);
                AddStringContent(form, $"{JSON_CUSTOM_ATTRIBUTE_VALUES}[][custom_attribute_id]", t.CustomAttributeId);
                AddStringContent(form, $"{JSON_CUSTOM_ATTRIBUTE_VALUES}[][scanner_code_type]", t.ScannerCodeType);
            }

            foreach (var t in (OptionValueIds ?? Enumerable.Empty<Guid>()))
                AddStringContent(form, $"{JSON_OPTION_VALUE_IDS}[]", t.ToString());

            foreach (var t in (PhotoIds ?? Enumerable.Empty<int>()))
                AddStringContent(form, $"{JSON_PHOTO_IDS}[]", t.ToString());

            foreach (var p in (Photos ?? Enumerable.Empty<PhotoRequest>()))
            {
                if (p.PhotoRequestType == PhotoRequestType.Path)
                {
                    var file = fileSystem.File.ReadAllBytes(p.Content);

                    form.Add(new ByteArrayContent(file, 0, file.Length), $"{JSON_PHOTOS}[]", Path.GetFileName(p.Content));
                }
                else if (p.PhotoRequestType.HasFlag(PhotoRequestType.Url | PhotoRequestType.Blob))
                    AddStringContent(form, $"{JSON_PHOTOS}[]", p.Content);
            }

            return form;
        }
    }
}
