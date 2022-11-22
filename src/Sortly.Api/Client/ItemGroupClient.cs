using Sortly.Api.Client.Base;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;
using Sortly.Api.Model.Response;

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
        Task<ItemGroupResponse> CreateItemGroup(CreateItemGroupRequest request);

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
        Task<ItemGroupResponse> UpdateItemGroup(Guid id, UpdateItemGroupRequest request);

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
        private readonly IPayloadResolver _payloadResolver;

        public ItemGroupClient(ISortlyApiAdapter api, IPayloadResolver payloadResolver) : base()
        {
            Guard.ArgumentsAreNotNull(api, payloadResolver);

            _api = api;
            _payloadResolver = payloadResolver;
        }

        public async Task<ItemGroupResponse> CreateItemGroup(CreateItemGroupRequest request)
        {
            Guard.ArgumentIsNotNull(request, "CreateItemGroupRequest is required");
            request.Validate();

            var response = await _api.Post(Route.ItemGroups, _payloadResolver.ResolveMultiPart(request));

            return await ProcessResponse<ItemGroupResponse>(response);
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

        public async Task<ItemGroupResponse> UpdateItemGroup(Guid id, UpdateItemGroupRequest request)
        {
            // TODO: why is update not like create with a wrapping dto?
            Guard.ArgumentIsNotNull(request, "UpdateItemGroupRequest is required");
            request.Validate();

            var response = await _api.Put($"{Route.ItemGroups}/{id}", _payloadResolver.ResolveMultiPart(request));

            return await ProcessResponse<ItemGroupResponse>(response);
        }

        public async Task<EmptyResponse> DeleteItemGroup(Guid id)
        {
            var response = await _api.Delete($"{Route.ItemGroups}/{id}");

            return await ProcessNoContentResponse(response);
        }
    }
}
