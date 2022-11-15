using Sortly.Api.Model.Response.Abstractions;
using Sortly.Api.Model.Sortly;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    public class ListCustomFieldsResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public CustomField[] Data { get; set; }

        [JsonPropertyName("meta")]
        public Metadata Metadata { get; set; }
    }
}
