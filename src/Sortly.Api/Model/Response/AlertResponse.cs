using Sortly.Api.Model.Response.Abstractions;
using Sortly.Api.Model.Sortly;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    public class AlertResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public Alert Data { get; set; }
    }
}
