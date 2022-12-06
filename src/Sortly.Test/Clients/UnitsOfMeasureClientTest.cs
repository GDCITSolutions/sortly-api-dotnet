using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;
using Sortly.Api.Common.Constants;
using Sortly.Api.Model.Sortly;
using System.Net;
using System.Text.Json;
using Sortly.Test.Clients.Concrete;
using Sortly.Api.Model.Response;
using Sortly.Api.Common.Exceptions;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All tests related to <see cref="UnitsOfMeasureClient"/>
    /// </summary>
    [TestFixture]
    public class UnitsOfMeasureClientTest
    {
        private Mock<ISortlyApiAdapter> _mockApi;

        /// <summary>
        /// Every time tests are executed, setup mock objects
        /// </summary>
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

            response.Headers.Add(SortlyHeaders.RateLimitMax, "1000");
            response.Headers.Add(SortlyHeaders.RateLimitRemaining, "10");
            response.Headers.Add(SortlyHeaders.RateLimitReset, "2000");

            return response;
        }

        /// <summary>
        /// Test that the constructor executes successfully given mock dependencies
        /// </summary>
        [Test]
        public void Constructor_Success()
        {
            Assert.DoesNotThrow(() => new UnitsOfMeasureClient(_mockApi.Object));
        }

        /// <summary>
        /// Test that given a null api reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Fail_Api()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitsOfMeasureClient(null));
        }

        /// <summary>
        /// Test ListUnitsOfMeasure successfully executes without exceptions thrown
        /// </summary>
        [Test]
        public void ListUnitsOfMeasure_Success()
        {
            var unitOfMeasure = new UnitOfMeasure();

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(unitOfMeasure, HttpStatusCode.OK));

            var testingResponse = Client.TestProcessEmptyReponse().Result;

            Assert.Multiple(() =>
            {
                Assert.That(testingResponse.RateLimit.Max, Is.EqualTo(1000));
                Assert.That(testingResponse.RateLimit.Remaining, Is.EqualTo(10));
                Assert.That(testingResponse.RateLimit.Reset, Is.EqualTo(2000));
            });
        }

        /// <summary>
        /// Test ListUnitsOfMeasure throws an exception if the response isn't a successful status code
        /// </summary>
        [Test]
        public void ListUnitsOfMeasure_Request_Response_Failure()
        {
            var unitOfMeasure = new UnitOfMeasure();

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(unitOfMeasure, HttpStatusCode.BadRequest));

            Assert.ThrowsAsync<SortlyApiException>(() => Client.TestProcessEmptyReponse());
        }

        private TestBaseClient Client { get { return new TestBaseClient(_mockApi.Object); } }

    }
}