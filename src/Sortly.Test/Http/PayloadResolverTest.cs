using Moq;
using NUnit.Framework;
using Sortly.Api.Http;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All unit tests related to <see cref="PayloadResolver"/>
    /// </summary>
    [TestFixture]
    public class PayloadResolverTest
    {
        /// <summary>
        /// Every time tests are executed, setup mock objects
        /// </summary>
        [SetUp]
        public void Setup()
        {

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
        /// Test that given a null file adapter reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Fail_FileAdapter()
        {
            Assert.Fail();
        }

        #region ResolveMultiPart With CreateItemRequest Tests

        /// <summary>
        /// Given that there are no photos in CreateItemRequest, serialize the entity to JSON 
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemRequest_NoPhotos()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in CreateItemRequest, verify that all properties are converted into a multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemRequest_With_Photos_All_Properties_Defined()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in CreateItemRequest, verify that a file will be loaded if the photo type is of "Path"
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemRequest_With_Photo_Path()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in CreateItemRequest, verify that the url/blob is correctly set in the multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemRequest_With_Blob_Or_Url()
        {
            Assert.Fail();
        }

        #endregion

        #region ResolveMultiPart With UpdateItemRequest Tests

        /// <summary>
        /// Given that there are no photos in UpdateItemRequest, serialize the entity to JSON 
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemRequest_NoPhotos()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in UpdateItemRequest, verify that all properties are converted into a multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemRequest_With_Photos_All_Properties_Defined()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in UpdateItemRequest, verify that a file will be loaded if the photo type is of "Path"
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemRequest_With_Photo_Path()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in UpdateItemRequest, verify that the url/blob is correctly set in the multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemRequest_With_Blob_Or_Url()
        {
            Assert.Fail();
        }

        #endregion

        #region ResolveMultiPart With CreateItemGroupRequest Tests

        /// <summary>
        /// Given that there are no photos in CreateItemGroupRequest, serialize the entity to JSON 
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemGroupRequest_NoPhotos()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in CreateItemGroupRequest, verify that all properties are converted into a multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemGroupRequest_With_Photos_All_Properties_Defined()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in CreateItemGroupRequest, verify that a file will be loaded if the photo type is of "Path"
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemGroupRequest_With_Photo_Path()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in CreateItemGroupRequest, verify that the url/blob is correctly set in the multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_CreateItemGroupRequest_With_Blob_Or_Url()
        {
            Assert.Fail();
        }

        #endregion

        #region ResolveMultiPart With UpdateItemGroupRequest Tests

        /// <summary>
        /// Given that there are no photos in UpdateItemGroupRequest, serialize the entity to JSON 
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemGroupRequest_NoPhotos()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in UpdateItemGroupRequest, verify that all properties are converted into a multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemGroupRequest_With_Photos_All_Properties_Defined()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in UpdateItemGroupRequest, verify that a file will be loaded if the photo type is of "Path"
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemGroupRequest_With_Photo_Path()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Given that there are photos in UpdateItemGroupRequest, verify that the url/blob is correctly set in the multipart form
        /// </summary>
        [Test]
        public void ResolveMultiPart_UpdateItemGroupRequest_With_Blob_Or_Url()
        {
            Assert.Fail();
        }

        #endregion
    }
}
