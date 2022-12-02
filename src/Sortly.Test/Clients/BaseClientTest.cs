using Moq;
using NUnit.Framework;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Exceptions;
using Sortly.Api.Http;
using Sortly.Api.Model.Response;
using Sortly.Api.Model.Sortly;
using Sortly.Test.Clients.Concrete;
using System.Net;
using System.Text.Json;

namespace Sortly.Test.Clients
{
    [TestFixture]
    public class BaseClientTest
    {
        private Mock<ISortlyApiAdapter> _mockApi;

        [SetUp]
        public void Setup()
        {
            _mockApi = new Mock<ISortlyApiAdapter>();
        }

        /// <summary>
        /// Build a <see cref="HttpResponseMessage"/> with headers and content
        /// </summary>
        /// <param name="body"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private HttpResponseMessage BuildResponse(object body, HttpStatusCode status) 
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(body)),
                StatusCode = status
            };

            response.Headers.Add(SortlyHeaders.RateLimitMax, "5");
            response.Headers.Add(SortlyHeaders.RateLimitRemaining, "6");
            response.Headers.Add(SortlyHeaders.RateLimitReset, "7");

            return response;
        }

        [Test]
        public void ProcessResponse_Success()
        {
            var item = new ItemResponse() 
            {
                Data = new Item() 
                {
                    Id = 1
                }
            };

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(item, HttpStatusCode.OK));

            var testingResponse = Client.TestProcessReponse().Result;

            Assert.Multiple(() =>
            {
                Assert.That(testingResponse.Data.Id, Is.EqualTo(1));
                Assert.That(testingResponse.RateLimit.Max, Is.EqualTo(5));
                Assert.That(testingResponse.RateLimit.Reset, Is.EqualTo(7));
                Assert.That(testingResponse.RateLimit.Remaining, Is.EqualTo(6));
            });
        }

        [Test]
        public void ProcessResponse_Error_Response()
        {
            var item = new ItemResponse()
            {
                Data = new Item()
                {
                    Id = 1
                }
            };

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(item, HttpStatusCode.BadRequest));

            Assert.ThrowsAsync<SortlyApiException>(() => Client.TestProcessReponse());
        }

        [Test]
        public void ProcessNoContentResponse_Success()
        {
            var emptyResponse = new EmptyResponse();

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(emptyResponse, HttpStatusCode.OK));

            var testingResponse = Client.TestProcessEmptyReponse().Result;

            Assert.Multiple(() =>
            {
                Assert.That(testingResponse.RateLimit.Max, Is.EqualTo(5));
                Assert.That(testingResponse.RateLimit.Reset, Is.EqualTo(7));
                Assert.That(testingResponse.RateLimit.Remaining, Is.EqualTo(6));
            });
        }

        [Test]
        public void ProcessNoContentResponse_Error_Response()
        {
            var emptyResponse = new EmptyResponse();

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(emptyResponse, HttpStatusCode.BadRequest));

            Assert.ThrowsAsync<SortlyApiException>(() => Client.TestProcessEmptyReponse());
        }

        private TestBaseClient Client { get { return new TestBaseClient(_mockApi.Object); } }
    }
}
