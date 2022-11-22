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
    public interface IAlertClient
    {
        /// <summary>
        /// Get all alerts.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/alerts/list-alerts"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListAlertsResponse> ListAlerts(ListAlertsRequest request);

        /// <summary>
        /// Create a single alert.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/alerts/create-an-alert"/>
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        Task<AlertResponse> CreateAlert(Alert alert);

        /// <summary>
        /// Update an alert.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/alerts/update-an-alert"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alert"></param>
        /// <returns></returns>
        Task<AlertResponse> UpdateAlert(int id, Alert alert);

        /// <summary>
        /// Delete an alert.
        /// 
        /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/alerts/delete-alert"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmptyResponse> DeleteAlert(int id);
    }

    public class AlertClient : BaseClient, IAlertClient
    {
        private readonly ISortlyApiAdapter _api;

        public AlertClient(ISortlyApiAdapter api) : base()
        {
            Guard.ArgumentsAreNotNull(api);

            _api = api;
        }

        public async Task<ListAlertsResponse> ListAlerts(ListAlertsRequest request)
        {
            var response = await _api.Get($"{Route.Alerts}{request?.AsQueryString() ?? ""}");

            return await ProcessResponse<ListAlertsResponse>(response);
        }

        public async Task<AlertResponse> CreateAlert(Alert alert)
        {
            Guard.ArgumentIsNotNull(alert, "Alert is required");

            var content = new StringContent(JsonSerializer.Serialize(alert), Encoding.UTF8, "application/json");
            var response = await _api.Post(Route.Alerts, content);

            return await ProcessResponse<AlertResponse>(response);
        }

        public async Task<AlertResponse> UpdateAlert(int id, Alert alert)
        {
            Guard.ArgumentIsNotNull(alert, "Alert is required");

            var content = new StringContent(JsonSerializer.Serialize(alert), Encoding.UTF8, "application/json");
            var response = await _api.Put($"{Route.Alerts}/{id}", content);

            return await ProcessResponse<AlertResponse>(response);
        }

        public async Task<EmptyResponse> DeleteAlert(int id)
        {
            var response = await _api.Delete($"{Route.Alerts}/{id}");

            return await ProcessNoContentResponse(response);
        }
    }
}
