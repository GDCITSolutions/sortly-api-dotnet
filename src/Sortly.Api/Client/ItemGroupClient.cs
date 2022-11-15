using Sortly.Api.Client.Base;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.File;
using Sortly.Api.Common.Util;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;
using Sortly.Api.Model.Response;
using Sortly.Api.Model.Sortly;
using System.Text.Json;

namespace Sortly.Api.Client
{
    public interface IItemGroupClient
    {
        /// <summary>
        /// Create a single item group
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/create-item-group"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListItemGroupsResponse> CreateItemGroup(CreateItemGroupRequest request);

        /// <summary>
        /// Get a list of item groups.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/list-of-item-groups"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListItemGroupsResponse> ListItemGroups(ListItemGroupsRequest request);

        /// <summary>
        /// Get a single item group.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/fetch-item-group"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ItemGroupResponse> GetItemGroup(Guid id, GetItemGroupRequest request);

        /// <summary>
        /// Update an item group.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/update-an-item-group"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        Task<ItemGroupResponse> UpdateItemGroup(Guid id, ItemGroup group);

        /// <summary>
        /// Delete an item group.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups/delete-item-group"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmptyResponse> DeleteItemGroup(Guid id);
    }

    public class ItemGroupClient : BaseClient, IItemGroupClient
    {
        private readonly ISortlyApiAdapter _api;

        public ItemGroupClient(ISortlyApiAdapter api) : base()
        {
            Guard.ArgumentsAreNotNull(api);

            _api = api;
        }

        public async Task<ListItemGroupsResponse> CreateItemGroup(CreateItemGroupRequest request)
        {
            Guard.ArgumentIsNotNull(request, "CreateItemGroupRequest is required");
            request.Validate();

            var response = await _api.Post(Route.ItemGroups, JsonSerializer.Serialize(request));

            return await ProcessResponse<ListItemGroupsResponse>(response);
        }

        public async Task<ListItemGroupsResponse> ListItemGroups(ListItemGroupsRequest request)
        {
            var response = await _api.Get($"{Route.ItemGroups}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ListItemGroupsResponse>(response);
        }

        public async Task<ItemGroupResponse> GetItemGroup(Guid id, GetItemGroupRequest request)
        {
            var response = await _api.Get($"{Route.ItemGroups}/{id}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ItemGroupResponse>(response);
        }

        public async Task<ItemGroupResponse> UpdateItemGroup(Guid id, ItemGroup group)
        {
            // TODO: why is update not like create with a wrapping dto?
            Guard.ArgumentIsNotNull(group, "ItemGroup is required");
            group.Validate();

            var response = await _api.Put($"{Route.ItemGroups}/{id}", JsonSerializer.Serialize(group));

            return await ProcessResponse<ItemGroupResponse>(response);
        }

        public async Task<EmptyResponse> DeleteItemGroup(Guid id)
        {
            var response = await _api.Delete($"{Route.ItemGroups}/{id}");

            return await ProcessNoContentResponse(response);
        }
    }
}
