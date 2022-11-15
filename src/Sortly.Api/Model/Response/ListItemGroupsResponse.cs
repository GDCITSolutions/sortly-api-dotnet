using Sortly.Api.Model.Response.Abstractions;
using Sortly.Api.Model.Sortly;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    public class ListItemGroupsResponse : BaseResponse
    {
        [JsonPropertyName("item_groups")]
        public ItemGroup[] ItemGroups { get; set; }

        [JsonPropertyName("meta")]
        public Metadata Metadata { get; set; }
    }
}
