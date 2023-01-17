using Sortly.Api.Client.Base;
using Sortly.Api.Http;
using Sortly.Api.Model.Response;

namespace Sortly.Test.Clients.Concrete
{
    internal interface ITestBaseClient
    {
        /// <summary>
        /// Used for testing the methods that <see cref="BaseClient"/> provides
        /// </summary>
        /// <returns></returns>
        Task<ItemResponse> TestProcessReponse();

        /// <summary>
        /// Used for testing the methods that <see cref="BaseClient"/> provides
        /// </summary>
        /// <returns></returns>
        Task<EmptyResponse> TestProcessEmptyReponse();
    }

    /// <summary>
    /// Concrete implementation of <see cref="BaseClient"/> for testing usage.
    /// </summary>
    internal class TestBaseClient : BaseClient, ITestBaseClient
    {
        private readonly ISortlyApiAdapter _api;

        public TestBaseClient(ISortlyApiAdapter api) : base()
        {
            _api = api;
        }

        /// <summary>
        /// Method used for testing <see cref="BaseClient.ProcessResponse{T}(HttpResponseMessage)"/>
        /// </summary>
        /// <returns></returns>
        public async Task<ItemResponse> TestProcessReponse()
        {
            var response = await _api.Get("");

            return await ProcessResponse<ItemResponse>(response);
        }

        /// <summary>
        /// Method used for testing <see cref="BaseClient.ProcessNoContentResponse(HttpResponseMessage)"/>
        /// </summary>
        /// <returns></returns>
        public async Task<EmptyResponse> TestProcessEmptyReponse()
        {
            var response = await _api.Get("");

            return await ProcessNoContentResponse(response);
        }
    }
}
