using Sortly.Api.Client.Base;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Util;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;
using Sortly.Api.Model.Response;

namespace Sortly.Api.Client
{
    public interface ICustomFieldClient
    {
        /// <summary>
        /// Get all custom fields.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/custom-fieldsattributes/list-custom-fields"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListCustomFieldsResponse> ListCustomFields(ListCustomFieldsRequest request);
    }

    public class CustomFieldClient : BaseClient, ICustomFieldClient
    {
        private readonly ISortlyApiAdapter _api;

        public CustomFieldClient(ISortlyApiAdapter api) : base()
        {
            Guard.ArgumentsAreNotNull(api);

            _api = api;
        }

        public async Task<ListCustomFieldsResponse> ListCustomFields(ListCustomFieldsRequest request)
        {
            var response = await _api.Get($"{Route.CustomFields}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ListCustomFieldsResponse>(response);
        }
    }
}
