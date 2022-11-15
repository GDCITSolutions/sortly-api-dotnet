using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for getting a list of item groups
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/list-of-item-groups"/>
    /// </summary>
    public class ListItemGroupsRequest
    {
        public ListItemGroupsRequest() { }

        public ListItemGroupsRequest(int? perPage, int? page, DateTimeOffset? updatedSince)
        {
            PerPage = perPage;
            Page = page;
            UpdatedSince = updatedSince;
        }

        public int? PerPage { get; private set; }

        public int? Page { get; private set; }

        public IList<string> Include { get; private set; } = new List<string>();

        public DateTimeOffset? UpdatedSince { get; private set; }

        public ListItemGroupsRequest WithPerPage(int perPage)
        {
            PerPage = perPage;

            return this;
        }

        public ListItemGroupsRequest WithPage(int page)
        {
            Page = page;

            return this;
        }

        public ListItemGroupsRequest WithUpdatedSince(DateTimeOffset date)
        {
            UpdatedSince = date;

            return this;
        }

        public ListItemGroupsRequest IncludeVariants()
        {
            Include.Add(IncludeKeys.Variants);

            return this;
        }

        public ListItemGroupsRequest IncludePhotos()
        {
            Include.Add(IncludeKeys.Photos);

            return this;
        }

        public string AsQueryString() 
        {
            if (PerPage == null && Page == null && UpdatedSince == null && Include.Count == 0)
                return "";

            string parameters = "?";

            if (PerPage != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"per_page={PerPage}");

            if (Page != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"page={Page}");

            if (Include.Count > 0)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"include={string.Join(',', Include)}");

            if (UpdatedSince != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"updated_since={UpdatedSince?.ToUnixTimeSeconds()}");

            return parameters;
        }
    }
}
