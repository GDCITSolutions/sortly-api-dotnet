namespace Sortly.Api.Configuration
{
    public class SortlyApiConfiguration
    {
        public string BaseAddress { get; set; } = "https://api.sortly.co";

        public string ApiBearerToken { get; set; } = "";
    }
}
