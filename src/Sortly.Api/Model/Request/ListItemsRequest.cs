using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for getting a list of items
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/list-items"/>
    /// </summary>
    public class ListItemsRequest
    {
        public ListItemsRequest() { }

        public ListItemsRequest(int? perPage, int? page, string folderId) 
        {
            PerPage = perPage;
            Page = page;
            FolderId = folderId;
        }

        public int? PerPage { get; private set; }

        public int? Page { get; private set; }

        public string FolderId { get; private set; }

        public IList<string> Include { get; private set; } = new List<string>();

        public ListItemsRequest WithPerPage(int perPage)
        {
            PerPage = perPage;

            return this;
        }

        public ListItemsRequest WithPage(int page)
        {
            Page = page;

            return this;
        }

        public ListItemsRequest WithFolderId(string folderId)
        {
            FolderId = folderId;

            return this;
        }

        public ListItemsRequest IncludeCustomAttributes()
        {
            Include.Add(IncludeKeys.CustomAttributes);

            return this;
        }

        public ListItemsRequest IncludePhotos()
        {
            Include.Add(IncludeKeys.Photos);

            return this;
        }

        public ListItemsRequest IncludeOptions()
        {
            Include.Add(IncludeKeys.Options);

            return this;
        }

        public string AsQueryString() 
        {
            if (PerPage == null && Page == null && FolderId == null && Include.Count == 0)
                return "";

            string parameters = "?";

            if (PerPage != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"per_page={PerPage}");

            if (Page != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"page={Page}");

            if (FolderId != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"folder_id={FolderId}");

            if (Include.Count > 0)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"include={string.Join(',', Include)}");

            return parameters;
        }
    }
}
