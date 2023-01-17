using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All tests related to <see cref="SortlyClient"/>
    /// </summary>
    [TestFixture]
    public class SortlyClientTest
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

        }

        /// <summary>
        /// Test that given a null api reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Failure()
        {

        }

        /// <summary>
        /// Test that each of the client properties are defined after initialization
        /// </summary>
        [Test]
        public void Sub_Clients_Are_Defined()
        {

        }
    }
}
