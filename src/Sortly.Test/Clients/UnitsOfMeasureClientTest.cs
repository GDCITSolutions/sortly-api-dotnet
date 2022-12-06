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
           
            var testList = new List<UnitOfMeasure>() { new UnitOfMeasure { PrettyName = "Some Pretty Name", PrettyUnit = "Some Pretty Unit", Scale = 1, UnitName = "Some Unit Name", UnitType = "Some Unit Type" } };

            var testHttpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(JsonSerializer.Serialize(testList)),
                StatusCode = HttpStatusCode.OK,
            };

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(testHttpResponseMessage);
            var unitOfMeasureClient = new UnitsOfMeasureClient(_mockApi.Object);
            var result = unitOfMeasureClient.ListUnitsOfMeasure().Result;

            Assert.That(result, Is.InstanceOf<List<UnitOfMeasure>>());
            Assert.That(result.Count, Is.EqualTo(testList.Count));
            Assert.That(result[0].PrettyName, Is.EqualTo("Some Pretty Name"));
            Assert.That(result[0].PrettyUnit, Is.EqualTo("Some Pretty Unit"));
            Assert.That(result[0].Scale, Is.EqualTo(1));
            Assert.That(result[0].UnitName, Is.EqualTo("Some Unit Name"));
            Assert.That(result[0].UnitType, Is.EqualTo("Some Unit Type"));
        }

        /// <summary>
        /// Test ListUnitsOfMeasure throws an exception if the response isn't a successful status code
        /// </summary>
        [Test]
        public void ListUnitsOfMeasure_Request_Response_Failure()
        {
            var testHttpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(testHttpResponseMessage);
            var unitOfMeasureClient = new UnitsOfMeasureClient(_mockApi.Object);
            var result = unitOfMeasureClient.ListUnitsOfMeasure();

            Assert.That(result, Is.InstanceOf<List<UnitOfMeasure>>());
            Assert.ThrowsAsync<SortlyApiException>(() => result);
        }

    }
}