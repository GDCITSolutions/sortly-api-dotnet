using Sortly.Api.Model.Response.Abstractions;
using Sortly.Api.Model.Sortly;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    public class ItemGroupResponse : BaseResponse
    {
        [JsonPropertyName("item_group")]
        public ItemGroup ItemGroup { get; set; }
    }
}
