using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class CustomAttribute: IValidatable
    {
        [JsonPropertyName("custom_attribute_id")]
        public int? CustomAttributeId { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("attribute_value")]
        public string AttributeValue { get; set; }

        /// <summary>
        /// <see cref="ScannerCodeTypes"/> for valid values
        /// </summary>
        [JsonPropertyName("scanner_code_type")]
        public string ScannerCodeType { get; set; }

        public void Validate()
        {
            if (CustomAttributeId == null)
                throw new SortlyValidationException("CustomAttributeId is required");

            if (string.IsNullOrEmpty(Value))
                throw new SortlyValidationException("Value is required");

            if (string.IsNullOrEmpty(AttributeValue))
                throw new SortlyValidationException("AttributeValue is required");
        }
    }
}
