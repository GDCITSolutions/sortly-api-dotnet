using Sortly.Api.Client.Base;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;
using Sortly.Api.Model.Response;
using Sortly.Api.Model.Sortly;
using System.Text;
using System.Text.Json;

namespace Sortly.Api.Client
{
    public interface IItemClient 
    {
        /// <summary>
        /// Create an item in Sortly.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/create-an-item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<ItemResponse> CreateItem(CreateItemRequest request);

        /// <summary>
        /// Get a single item in Sortly.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/fetch-item"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ItemResponse> GetItem(int id, GetItemRequest request);

        /// <summary>
        /// Delete a single item in Sortly.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/delete-item"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmptyResponse> DeleteItem(int id);

        /// <summary>
        /// Get a list of items in Sortly.
        /// 
        /// This is subject to pagination so multiple requests might be required to fully get the list of items.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/list-items"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListItemsResponse> ListItems(ListItemsRequest request);

        /// <summary>
        /// Get a list of recent items in Sortly.
        /// 
        /// This is subject to pagination so multiple requests might be required to fully get the list of items.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/recent-items-list"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListItemsResponse> ListRecentItems(ListRecentItemsRequest request);

        /// <summary>
        /// Move an item to a new folder.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/move-an-item"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ItemResponse> MoveItem(int id, MoveItemRequest request);

        /// <summary>
        /// Clone an item and place in some folder.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/clone-an-item"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ItemResponse> CloneItem(int id, CloneItemRequest request);

        /// <summary>
        /// Update a single item in Sortly.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/update-item"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<EmptyResponse> UpdateItem(int id, UpdateItemRequest request);

        /// <summary>
        /// Search for items.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/search-items"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListItemsResponse> SearchItems(SearchItemsRequest request);
    }

    public class ItemClient : BaseClient, IItemClient
    {
        private readonly ISortlyApiAdapter _api;
        private readonly IPayloadResolver _payloadResolver;

        public ItemClient(ISortlyApiAdapter api, IPayloadResolver payloadResolver) : base()
        {
            Guard.ArgumentsAreNotNull(api, payloadResolver);

            _api = api;
            _payloadResolver = payloadResolver;
        }

        public async Task<ItemResponse> GetItem(int id, GetItemRequest request)
        {
            var response = await _api.Get($"{Route.Items}/{id}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ItemResponse>(response);
        }

        public async Task<ItemResponse> CreateItem(CreateItemRequest request)
        {
            Guard.ArgumentIsNotNull(request, "CreateItemRequest is required");
            request.Validate();

            var response = await _api.Post(Route.Items, _payloadResolver.ResolveMultiPart(request));

            return await ProcessResponse<ItemResponse>(response);
        }

        public async Task<ItemResponse> MoveItem(int id, MoveItemRequest request)
        {
            Guard.ArgumentIsNotNull(request, "MoveItemRequest is required");
            request.Validate();

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _api.Post($"{Route.Items}/{id}/move", content);

            return await ProcessResponse<ItemResponse>(response);
        }

        public async Task<ItemResponse> CloneItem(int id, CloneItemRequest request)
        {
            Guard.ArgumentIsNotNull(request, "CloneItemRequest is required");

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _api.Post($"{Route.Items}/{id}/copy", content);

            return await ProcessResponse<ItemResponse>(response);
        }

        public async Task<EmptyResponse> UpdateItem(int id, UpdateItemRequest request)
        {
            Guard.ArgumentIsNotNull(request, "UpdateItemRequest is required");
            request.Validate();

            var response = await _api.Put($"{Route.Items}/{id}", _payloadResolver.ResolveMultiPart(request));

            return await ProcessNoContentResponse(response);
        }

        public async Task<EmptyResponse> DeleteItem(int id)
        {
            var response = await _api.Delete($"{Route.Items}/{id}");

            return await ProcessNoContentResponse(response);
        }

        public async Task<ListItemsResponse> ListItems(ListItemsRequest request)
        {
            var response = await _api.Get($"{Route.Items}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ListItemsResponse>(response);
        }

        public async Task<ListItemsResponse> ListRecentItems(ListRecentItemsRequest request)
        {
            var response = await _api.Get($"{Route.RecentItems}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ListItemsResponse>(response);
        }

        public async Task<ListItemsResponse> SearchItems(SearchItemsRequest request)
        {
            var response = await _api.Get($"{Route.SearchItems}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ListItemsResponse>(response);
        }
    }
}
