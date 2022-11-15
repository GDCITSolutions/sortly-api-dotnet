using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class ItemGroup : IValidatable
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

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

        [JsonPropertyName("photo_ids")]
        public int[] PhotoIds { get; set; }

        [JsonPropertyName("photos")]
        public Photo[] Photos { get; set; }

        [JsonPropertyName("attributes")]
        public ItemGroupAttribute[] Attributes { get; set; }

        [JsonPropertyName("variants")]
        public ItemGroupVariant[] Variants { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new SortlyValidationException("Name is required");

            if ((Attributes?.Length ?? 0) == 0)
                throw new SortlyValidationException("At least one attribute is required");

            for (int i = 0; i < Attributes.Length - 1; i++)
            {
                var attribute = Attributes[i];

                if (string.IsNullOrEmpty(attribute.Name))
                    throw new SortlyValidationException($"Group attribute at index {i} - Name is required.");

                if (attribute.Order == null)
                    throw new SortlyValidationException($"Group attribute at index {i} - Order is required.");

                if ((attribute.Options?.Length ?? 0) == 0)
                    throw new SortlyValidationException($"Group attribute at index {i} - At least one option is required.");

                for (int j = 0; j < attribute.Options.Length - 1; j++)
                {
                    var option = attribute.Options[j];

                    if (string.IsNullOrEmpty(option.Name))
                        throw new SortlyValidationException($"Group attribute at index {i}, Option at index {j} - Name is required.");

                    if (option.Order == null)
                        throw new SortlyValidationException($"Group attribute at index {i}, Option at index {j} - Order is required.");
                }
            }
        }
    }
}
