using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Response
{
    /// <summary>
    /// Hold metadata information for some response regarding pagination.
    /// 
    /// API documentation lies, pagination is actually metadata
    /// </summary>
    public class Metadata
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("next_page_url")]
        public string NextPageUrl { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
    }
}
