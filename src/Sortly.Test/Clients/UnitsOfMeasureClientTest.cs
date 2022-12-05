using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

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
            Assert.Fail();
        }

        /// <summary>
        /// Test that given a null api reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Fail_Api() 
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test ListUnitsOfMeasure successfully executes without exceptions thrown
        /// </summary>
        [Test]
        public void ListUnitsOfMeasure_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test ListUnitsOfMeasure throws an exception if the response isn't a successful status code
        /// </summary>
        [Test]
        public void ListUnitsOfMeasure_Request_Response_Failure()
        {
            Assert.Fail();
        }
    }
}
