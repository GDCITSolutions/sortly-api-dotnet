using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Response.Abstractions;
using Sortly.Api.Model.Response;
using System.Text.Json;

namespace Sortly.Api.Client.Base
{
    public abstract class BaseClient
    {
        /// <summary>
        /// Read Sortly API response headers and place them within a <see cref="RateLimit"/>
        /// 
        /// Information available:
        /// 
        /// How many requests can be executed within the time limit
        /// How many requests remaining within the time limit
        /// Time until the limit resets in seconds
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private RateLimit ParseRateLimitHeaders(HttpResponseMessage response)
        {
            // note, api documentation is conflicting
            // it says that all responses will have these headers but some individual endpoints are listed without them
            int.TryParse(response.Headers.FirstOrDefault(x => x.Key == SortlyHeaders.RateLimitMax).Value.First(), out int rateLimitMax);
            int.TryParse(response.Headers.FirstOrDefault(x => x.Key == SortlyHeaders.RateLimitRemaining).Value.First(), out int rateLimitRemaining);
            int.TryParse(response.Headers.FirstOrDefault(x => x.Key == SortlyHeaders.RateLimitReset).Value.First(), out int rateLimitReset);

            return new RateLimit()
            {
                Max = rateLimitMax,
                Remaining = rateLimitRemaining,
                Reset = rateLimitReset
            };
        }

        protected async Task<T> ProcessResponse<T>(HttpResponseMessage response) where T : BaseResponse
        {
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new SortlyApiException(JsonSerializer.Deserialize<ErrorResponse>(content).Message);

            var deserialized = JsonSerializer.Deserialize<T>(content);
            deserialized.RateLimit = ParseRateLimitHeaders(response);

            return deserialized;
        }

        /// <summary>
        /// Some endpoints return literally nothing within the body of the response.
        /// 
        /// Need to handle this as an <see cref="EmptyResponse"/>
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="SortlyApiException"></exception>
        protected async Task<EmptyResponse> ProcessNoContentResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new SortlyApiException(JsonSerializer.Deserialize<ErrorResponse>(content).Message);

            return new EmptyResponse()
            {
                RateLimit = ParseRateLimitHeaders(response)
            };
        }
    }
}
