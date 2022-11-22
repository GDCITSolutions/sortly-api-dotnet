using Sortly.Api.Common.Util;
using Sortly.Api.Configuration;
using System.Text;

namespace Sortly.Api.Http
{
    public interface ISortlyApiAdapter
    {
        Task<HttpResponseMessage> Get(string path);

        Task<HttpResponseMessage> Post(string path, HttpContent content);

        Task<HttpResponseMessage> Delete(string path);

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
