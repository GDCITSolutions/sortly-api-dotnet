using Sortly.Api.Common.Constants;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Sortly
{
    public class CustomAttribute
    {
        [JsonPropertyName("custom_attribute_id")]
        public int CustomAttributeId { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("attribute_value")]
        public string AttributeValue { get; set; }

        /// <summary>
        /// <see cref="ScannerCodeTypes"/> for valid values
        /// </summary>
        [JsonPropertyName("scanner_code_type")]
        public string ScannerCodeType { get; set; }
    }
}
