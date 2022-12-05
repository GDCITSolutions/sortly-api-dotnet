using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

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
        /// Test ListCustomFields with an object that resolves to a query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListCustomFields_Success_With_Query_String()
        {
            Assert.Fail();
        }


        /// <summary>
        /// Test ListCustomFields with an object that resolves to an empty query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListCustomFields_Success_Without_Query_String()
        {
            Assert.Fail();
        }
    }
}
