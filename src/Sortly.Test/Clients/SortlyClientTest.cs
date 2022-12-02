using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

namespace Sortly.Test.Clients
{
    [TestFixture]
    public class SortlyClientTest
    {
        private Mock<ISortlyApiAdapter> _mockApi;

        [SetUp]
        public void Setup() 
        {
            _mockApi = new Mock<ISortlyApiAdapter>();
        }

        [Test]
        public void Constructor_Success()
        {

        }

        [Test]
        public void Constructor_Failure()
        {

        }

        [Test]
        public void Sub_Clients_Are_Defined()
        {

        }
    }
}
