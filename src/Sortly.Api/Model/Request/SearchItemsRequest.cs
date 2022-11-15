using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;
using System.Text.Json;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Model query parameters for searching items
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/search-items"/>
    /// </summary>
    public class SearchItemsRequest
    {
        public SearchItemsRequest() { }

        public SearchItemsRequest(int? perPage, int? page, string name, string type, IList<string> folderIds)
        {
            PerPage = perPage;
            Page = page;
            Name = name;
            Type = type;
            FolderIds = folderIds ?? new List<string>();
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        /// <summary>
        /// Dictionary of keys to sort by
        /// 
        /// Note, only name sorting is supported at the moment
        /// </summary>
        public IDictionary<string, string> Sort { get; private set; } = new Dictionary<string, string>();

        public Guid? ItemGroupId { get; private set; }

        public int? PerPage { get; private set; }

        public int? Page { get; private set; }

        public IList<string> FolderIds { get; private set; } = new List<string>();

        public IList<string> Include { get; private set; } = new List<string>();

        public SearchItemsRequest WithItemGroupId(Guid itemGroupId)
        {
            ItemGroupId = itemGroupId;

            return this;
        }

        public SearchItemsRequest WithType(string type)
        {
            Type = type;

            return this;
        }

        public SearchItemsRequest WithName(string name)
        {
            Name = name;

            return this;
        }

        public SearchItemsRequest WithPerPage(int perPage)
        {
            PerPage = perPage;

            return this;
        }

        public SearchItemsRequest WithPage(int page)
        {
            Page = page;

            return this;
        }

        public SearchItemsRequest WithFolderId(string folderId)
        {
            FolderIds.Add(folderId);

            return this;
        }

        public SearchItemsRequest WithFolderIds(IList<string> folderIds)
        {
            FolderIds = folderIds ?? new List<string>();

            return this;
        }

        public SearchItemsRequest IncludeCustomAttributes()
        {
            Include.Add(IncludeKeys.CustomAttributes);

            return this;
        }

        public SearchItemsRequest IncludePhotos()
        {
            Include.Add(IncludeKeys.Photos);

            return this;
        }

        public SearchItemsRequest IncludeOptions()
        {
            Include.Add(IncludeKeys.Options);

            return this;
        }

        public SearchItemsRequest SortByNameAscending()
        {
            Sort["name"] = "asc";

            return this;
        }

        public SearchItemsRequest SortByNameDescending()
        {
            Sort["name"] = "desc";

            return this;
        }

        public string AsQueryString() 
        {
            if (Name == null && Type == null 
                    && Sort.Count == 0 && ItemGroupId == null
                    && PerPage == null && Page == null
                    && FolderIds.Count == 0 && Include.Count == 0)
                return "";

            string parameters = "?";

            if (PerPage != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"per_page={PerPage}");

            if (Page != null) 
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"page={Page}");

            if (ItemGroupId != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"item_group_id={ItemGroupId}");

            if (Type != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"type={Type}");

            if (Name != null)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"name={Name}");

            // api is expecting a json array in the query string
            if (FolderIds.Count > 0)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"folder_ids={JsonSerializer.Serialize(FolderIds)}");

            // api is expecting json in the query string
            if (Sort.Count > 0)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"sort={JsonSerializer.Serialize(Sort)}");

            if (Include.Count > 0)
                parameters += StringHelpers.FormatQueryParameterAddition(parameters, $"include={string.Join(',', Include)}");

            return parameters;
        }
    }
}
