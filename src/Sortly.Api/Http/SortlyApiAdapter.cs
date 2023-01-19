using Sortly.Api.Common.Util;
using Sortly.Api.Configuration;

namespace Sortly.Api.Http
{
    public interface ISortlyApiAdapter
    {
        /// <summary>
        /// Call a GET endpoint of Sortly
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Get(string path);

        /// <summary>
        /// Call a POST endpoint of Sortly
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Post(string path, HttpContent content);

        /// <summary>
        /// Call a DELETE endpoint of Sortly
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Delete(string path);

        /// <summary>
        /// Call a PUT endpoint of Sortly
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> Put(string path, HttpContent content);
    }

    public class SortlyApiAdapter : ISortlyApiAdapter
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly SortlyApiConfiguration _config;

        public SortlyApiAdapter(IHttpClientFactory clientFactory, SortlyApiConfiguration config)
        {
            Guard.ArgumentsAreNotNull(clientFactory, config);

            _clientFactory = clientFactory;
            _config = config;
        }

        private HttpClient BuildClient()
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_config.BaseAddress);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config.ApiBearerToken}");

            return client;
        }

        public async Task<HttpResponseMessage> Get(string path)
        {
            return await BuildClient().GetAsync(path);
        }

        public async Task<HttpResponseMessage> Post(string path, HttpContent content)
        {
            return await BuildClient().PostAsync(path, content);
        }

        public async Task<HttpResponseMessage> Put(string path, HttpContent content)
        {
            return await BuildClient().PutAsync(path, content);
        }

        public async Task<HttpResponseMessage> Delete(string path)
        {
            return await BuildClient().DeleteAsync(path);
        }
    }
}
