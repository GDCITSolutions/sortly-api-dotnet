using Sortly.Api.Client.Base;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Exceptions;
using Sortly.Api.Common.Util;
using Sortly.Api.Http;
using Sortly.Api.Model.Response;
using Sortly.Api.Model.Sortly;
using System.Text.Json;

namespace Sortly.Api.Client
{
    public interface IUnitsOfMeasureClient
    {
        /// <summary>
        /// Get all units of measure.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/units-of-measure/list-of-units"/>
        /// </summary>
        /// <returns></returns>
        Task<List<UnitOfMeasure>> ListUnitsOfMeasure();
    }

    public class UnitsOfMeasureClient : BaseClient, IUnitsOfMeasureClient
    {
        private readonly ISortlyApiAdapter _api;

        public UnitsOfMeasureClient(ISortlyApiAdapter api) : base()
        {
            Guard.ArgumentsAreNotNull(api);

            _api = api;
        }

        public async Task<List<UnitOfMeasure>> ListUnitsOfMeasure()
        {
            // note, this endpoint doesn't follow the standards of the rest of the endpoints
            var response = await _api.Get(Route.UnitsOfMeasure);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new SortlyApiException(JsonSerializer.Deserialize<ErrorResponse>(content).Message);

            return JsonSerializer.Deserialize<List<UnitOfMeasure>>(content);
        }
    }
}
