using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    public class ErrorResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
