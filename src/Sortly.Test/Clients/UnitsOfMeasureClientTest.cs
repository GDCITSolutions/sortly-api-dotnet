using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

namespace Sortly.Test.Clients
{
    [TestFixture]
    public class UnitsOfMeasureClientTest
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
            Assert.Fail();
        }

        [Test]
        public void Constructor_Fail_Api() 
        {
            Assert.Fail();
        }

        [Test]
        public void ListUnitsOfMeasure_Success()
        {
            Assert.Fail();
        }

        [Test]
        public void ListUnitsOfMeasure_Request_Response_Failure()
        {
            Assert.Fail();
        }
    }
}
