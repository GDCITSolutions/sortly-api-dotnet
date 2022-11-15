using Sortly.Api.Model.Response.Abstractions;
using Sortly.Api.Model.Sortly;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    public class ListItemsResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public Item[] Data { get; set; }

        [JsonPropertyName("meta")]
        public Metadata Metadata { get; set; }
    }
}
