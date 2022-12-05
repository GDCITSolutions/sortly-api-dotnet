using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All tests related to <see cref="ItemClient"/>
    /// </summary>
    [TestFixture]
    public class ItemClientTest
    {
        /// <summary>
        /// Every time tests are executed, setup mock objects
        /// </summary>
        [SetUp]
        public void Setup() 
        {

        }

        #region Constructor Tests

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

        #endregion

        #region GetItem Tests

        /// <summary>
        /// Test GetItem with an object that resolves to a query string with no exceptions thrown
        /// </summary>
        [Test]
        public void GetItem_Success_With_Query_String()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test GetItem with an object that resolves to an empty query string with no exceptions thrown
        /// </summary>
        [Test]
        public void GetItem_Success_Without_Query_String()
        {
            Assert.Fail();
        }

        #endregion

        #region CreateItem Tests

        /// <summary>
        /// Test CreatItem that executes successfully end-to-end
        /// </summary>
        [Test]
        public void CreateItem_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test CreatItem throws an exception if no item is provided
        /// </summary>
        [Test]
        public void CreateItem_Null_Request()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="CreateItemRequest.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItem_Validation_Failure_Name()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="CreateItemRequest.Type"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItem_Validation_Failure_Type()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="CreateItemRequest.ItemGroupId"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItem_Validation_Failure_With_ItemGroupId_Null_OptionIds()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="CreateItemRequest.OptionValueIds"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItem_Validation_Failure_With_OptionIds_Null_ItemGroupId()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="CreateItemRequest.CustomAttributeValues"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItem_Validation_Failure_With_Invalid_CustomAttributeValues()
        {
            Assert.Fail();
        }

        #endregion

        #region UpdateItem Tests

        /// <summary>
        /// Test UpdateItem that executes successfully end-to-end
        /// </summary>
        [Test]
        public void UpdateItem_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test UpdateItem throws an exception if no item is provided
        /// </summary>
        [Test]
        public void UpdateItem_Null_Request()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="UpdateItemRequest.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItem_Validation_Failure_Name()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="UpdateItemRequest.Type"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItem_Validation_Failure_Type()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="UpdateItemRequest.ItemGroupId"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItem_Validation_Failure_With_ItemGroupId_Null_OptionIds()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="UpdateItemRequest.OptionValueIds"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItem_Validation_Failure_With_OptionIds_Null_ItemGroupId()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="UpdateItemRequest.CustomAttributeValues"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItem_Validation_Failure_With_Invalid_CustomAttributeValues()
        {
            Assert.Fail();
        }

        #endregion

        #region MoveItem Tests

        /// <summary>
        /// Test MoveItem that executes successfully end-to-end
        /// </summary>
        [Test]
        public void MoveItem_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test UpdateItem throws an exception if no movement information is provided
        /// </summary>
        [Test]
        public void MoveItem_Null_Request()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="MoveItemRequest.Quantity"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void MoveItem_Validation_Failure_With_Quantity()
        {
            Assert.Fail();
        }

        #endregion

        #region CloneItem Tests
        /// <summary>
        /// Test CloneItem that executes successfully end-to-end
        /// </summary>
        [Test]
        public void CloneItem_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test CloneItem throws an exception if no cloning information is provided
        /// </summary>
        [Test]
        public void CloneItem_Null_Request()
        {
            Assert.Fail();
        }

        #endregion

        #region DeleteItem Tests

        /// <summary>
        /// Test DeleteItem that executes successfully end-to-end
        /// </summary>
        [Test]
        public void DeleteItem_Success()
        {
            Assert.Fail();
        }

        #endregion

        #region ListItems Tests

        /// <summary>
        /// Test ListItems with an object that resolves to a query string
        /// </summary>
        [Test]
        public void ListItems_Success_With_Query_String()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test ListItems with an object that resolves to an empty query string
        /// </summary>
        [Test]
        public void ListItems_Success_Without_Query_String()
        {
            Assert.Fail();
        }

        #endregion

        #region ListRecentItems Tests

        /// <summary>
        /// Test ListRecentItems with an object that resolves to a query string
        /// </summary>
        [Test]
        public void ListRecentItems_Success_With_Query_String()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test ListRecentItems with an object that resolves to an empty query string
        /// </summary>
        [Test]
        public void ListRecentItems_Success_Without_Query_String()
        {
            Assert.Fail();
        }

        #endregion

        #region SearchItems Tests

        /// <summary>
        /// Test SearchItems with an object that resolves to a query string
        /// </summary>
        [Test]
        public void SearchItems_Success_With_Query_String()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test SearchItems with an object that resolves to an empty query string
        /// </summary>
        [Test]
        public void SearchItems_Success_Without_Query_String()
        {
            Assert.Fail();
        }

        #endregion
    }
}
