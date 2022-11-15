using Sortly.Api.Common.Constants;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for getting a single item group
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/fetch-item-group"/>
    /// </summary>
    public class GetItemGroupRequest
    {
        public IList<string> Include { get; private set; } = new List<string>();

        public GetItemGroupRequest IncludeVariants() 
        {
            Include.Add(IncludeKeys.Variants);

            return this;
        }

        public GetItemGroupRequest IncludePhotos()
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
