using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for getting a list of recent items
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/recent-items-list"/>
    /// </summary>
    public class ListRecentItemsRequest
    {
        public ListRecentItemsRequest() { }

        public ListRecentItemsRequest(int? perPage, int? page, DateTimeOffset? updatedSince)
        {
            PerPage = perPage;
            Page = page;
            UpdatedSince = updatedSince;
        }

        public int? PerPage { get; private set; }

        public int? Page { get; private set; }

        public IList<string> Include { get; private set; } = new List<string>();

        public DateTimeOffset? UpdatedSince { get; private set; }

        public ListRecentItemsRequest WithPerPage(int perPage)
        {
            PerPage = perPage;

            return this;
        }

        public ListRecentItemsRequest WithPage(int page)
        {
            Page = page;

            return this;
        }

        public ListRecentItemsRequest WithUpdatedSince(DateTimeOffset date)
        {
            UpdatedSince = date;

            return this;
        }

        public ListRecentItemsRequest IncludeCustomAttributes()
        {
            Include.Add(IncludeKeys.CustomAttributes);

            return this;
        }

        public ListRecentItemsRequest IncludePhotos()
        {
            Include.Add(IncludeKeys.Photos);

            return this;
        }

        public ListRecentItemsRequest IncludeOptions()
        {
            Include.Add(IncludeKeys.Options);

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
