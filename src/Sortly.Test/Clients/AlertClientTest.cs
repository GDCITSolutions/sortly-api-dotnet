using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All tests related to <see cref="AlertClient"/>
    /// </summary>
    [TestFixture]
    public class AlertClientTest
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
            Assert.DoesNotThrow(() => new AlertClient(_mockApi.Object));
        }

        /// <summary>
        /// Test that given a null api reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Fail_Api() 
        {
            Assert.Throws<ArgumentNullException>(() => new AlertClient(null));
        }

        /// <summary>
        /// Test ListAlerts with an object that resolves to a query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListAlerts_Success_With_Query_String()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test ListAlerts with an object that resolves to an empty query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListAlerts_Success_Empty_Query_String()
        {
            Assert.Fail();
        }
        
        /// <summary>
        /// Test CreateAlert from end to end with no exceptions thrown
        /// </summary>
        [Test]
        public void CreateAlert_Success()
        {
            Assert.Fail();
        }
        
        /// <summary>
        /// Test CreateAlert throws when not provided an alert
        /// </summary>
        [Test]
        public void CreateAlert_Null_Request()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test UpdateAlert from end to end with no exceptions thrown
        /// </summary>
        [Test]
        public void UpdateAlert_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test UpdateAlert throws when not provided an alert
        /// </summary>
        [Test]
        public void UpdateAlert_Null_Request()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test DeleteAlert from end to end with no exceptions thrown
        /// </summary>
        [Test]
        public void DeleteAlert_Success()
        {
            Assert.Fail();
        }
    }
}
