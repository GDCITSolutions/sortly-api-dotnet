using Sortly.Api.Common.Util;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for getting a list of items
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/list-items"/>
    /// </summary>
    public class ListCustomFieldsRequest
    {
        public ListCustomFieldsRequest() { }

        public ListCustomFieldsRequest(int? perPage, int? page)
        {
            PerPage = perPage;
            Page = page;
        }

        public int? PerPage { get; private set; }

        public int? Page { get; private set; }

        public ListCustomFieldsRequest WithPerPage(int perPage)
        {
            PerPage = perPage;

            return this;
        }

        public ListCustomFieldsRequest WithPage(int page)
        {
            Page = page;

            return this;
        }

        public string AsQueryString() 
        {
            if (PerPage == null && Page == null)
                return "";

            string parameters = "?";

            if (PerPage != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"per_page={PerPage}");

            if (Page != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"page={Page}");

            return parameters;
        }
    }
}
