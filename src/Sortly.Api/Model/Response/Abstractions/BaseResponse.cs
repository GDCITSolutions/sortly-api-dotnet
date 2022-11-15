using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response.Abstractions
{
    public abstract class BaseResponse
    {
        [JsonIgnore]
        public RateLimit RateLimit { get; set; }
    }
}
