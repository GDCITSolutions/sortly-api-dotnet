using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;

namespace Sortly.Test.Clients
{
    [TestFixture]
    public class AlertClientTest
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
            Assert.DoesNotThrow(() => new AlertClient(_mockApi.Object));
        }

        [Test]
        public void Constructor_Fail_Api() 
        {
            Assert.Throws<ArgumentNullException>(() => new AlertClient(null));
        }

        [Test]
        public void ListAlerts_Success_With_Query_String()
        {
            Assert.Fail();
        }

        [Test]
        public void ListAlerts_Success_Empty_Query_String()
        {
            Assert.Fail();
        }

        [Test]
        public void CreateAlert_Success()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateAlert_Success()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteAlert_Success()
        {
            Assert.Fail();
        }
    }
}
