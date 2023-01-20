using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Common.Constants;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;
using Sortly.Api.Model.Sortly;
using Sortly.Api.Model.Response;
using System.Net;
using System.Text.Json;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All tests related to <see cref="CustomFieldClient"/>
    /// </summary>
    [TestFixture]
    public class CustomFieldClientTest
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

            response.Headers.Add(SortlyHeaders.RateLimitMax, "5");
            response.Headers.Add(SortlyHeaders.RateLimitRemaining, "6");
            response.Headers.Add(SortlyHeaders.RateLimitReset, "7");

            return response;
        }

        /// <summary>
        /// Test that the constructor executes successfully given mock dependencies
        /// </summary>
        [Test]
        public void Constructor_Success()
        {
            Assert.DoesNotThrow(() => new CustomFieldClient(_mockApi.Object));
        }

        /// <summary>
        /// Test that given a null api reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Fail_Api()
        {
            Assert.Throws<ArgumentNullException>(() => new CustomFieldClient(null));
        }

        /// <summary>
        /// Test ListCustomFields with an object that resolves to a query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListCustomFields_Success_With_Query_String()
        {
            var customFieldResponse = new ListCustomFieldsResponse()
            {
                Data = new[]
                {
                    new CustomField
                    {
                        Id = 1,
                        Name = "Field1"
                    },

                    new CustomField
                    {
                        Id = 2,
                        Name = "Field2"
                    }
                },

                Metadata = new Metadata()
                {
                    Page = 1
                }
            };

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(customFieldResponse, HttpStatusCode.OK));

            var customFieldClient = new CustomFieldClient(_mockApi.Object);
            var customFieldRequest = new ListCustomFieldsRequest(2, 1);

            var testingResult = customFieldClient.ListCustomFields(customFieldRequest).Result;

            for (int index = 0; index < testingResult.Data.Length; index++)
            {
                int id = index + 1;

                Assert.Multiple(() =>
                {
                    Assert.That(testingResult.Data[index].Id, Is.EqualTo(id));
                    Assert.That(testingResult.Data[index].Name, Is.EqualTo("Field" + id));
                });
            }

            Assert.That(testingResult.Metadata.Page, Is.EqualTo(1));
        }

        /// <summary>
        /// Test ListCustomFields with an object that resolves to an empty query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListCustomFields_Success_Without_Query_String()
        {
            var customFieldResponse = new ListCustomFieldsResponse()
            {
                Data = new[]
                {
                    new CustomField
                    {
                        Id = 1,
                        Name = "Field1"
                    },

                    new CustomField
                    {
                        Id = 2,
                        Name = "Field2"
                    }
                },

                Metadata = new Metadata()
                {
                    Page = 1
                }
            };

            _mockApi.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(BuildResponse(customFieldResponse, HttpStatusCode.OK));

            var customFieldClient = new CustomFieldClient(_mockApi.Object);
            var customFieldRequest = new ListCustomFieldsRequest();

            var testingResult = customFieldClient.ListCustomFields(customFieldRequest).Result;

            for (int index = 0; index < testingResult.Data.Length; index++)
            {
                int id = index + 1;

                Assert.Multiple(() =>
                {
                    Assert.That(testingResult.Data[index].Id, Is.EqualTo(id));
                    Assert.That(testingResult.Data[index].Name, Is.EqualTo("Field" + id));
                });
            }

            Assert.That(testingResult.Metadata.Page, Is.EqualTo(1));
        }
    }
}