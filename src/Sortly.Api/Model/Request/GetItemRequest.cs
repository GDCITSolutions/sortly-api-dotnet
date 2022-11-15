using Sortly.Api.Common.Constants;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for getting a single item
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/fetch-item"/>
    /// </summary>
    public class GetItemRequest
    {
        public IList<string> Include { get; private set; } = new List<string>();

        public GetItemRequest IncludeCustomAttributes()
        {
            Include.Add(IncludeKeys.CustomAttributes);

            return this;
        }

        public GetItemRequest IncludePhotos()
        {
            Include.Add(IncludeKeys.Photos);

            return this;
        }

        public string AsQueryString()
        {
            if (Include.Count == 0)
                return "";

            return $"?include={string.Join(',', Include)}";
        }
    }
}
