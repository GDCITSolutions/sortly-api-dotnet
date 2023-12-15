using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Sortly.Api.Client;
using Sortly.Api.Common.Constants;
using Sortly.Api.Common.Exceptions;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;
using Sortly.Api.Model.Response;
using Sortly.Api.Model.Sortly;
using System.ComponentModel.DataAnnotations;

namespace Sortly.Test.Clients
{
    /// <summary>
    /// All tests related to <see cref="ItemGroupClient"/>
    /// </summary>
    [TestFixture]
    public class ItemGroupClientTest
    {
        #region Mocks
        private Mock<ISortlyApiAdapter> _mockApi;
        private Mock<IPayloadResolver> _mockPayloadResolver;

        #endregion

        /// <summary>
        /// Every time tests are executed, setup mock objects
        /// </summary>
        [SetUp]
        public void Setup() 
        {
            _mockApi = new Mock<ISortlyApiAdapter>();
            _mockPayloadResolver = new Mock<IPayloadResolver>();
        }

        #region Constructor Tests
        
        /// <summary>
        /// Test that the constructor executes successfully given mock dependencies
        /// </summary>
        [Test]
        public void Constructor_Success()
        {
          Assert.DoesNotThrow(()=> new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object));
        }
        
        /// <summary>
        /// Test that given a null api reference, the constructor throws
        /// </summary>
        [Test]
        public void Constructor_Fail_Api() 
        { 
          Assert.Throws<ArgumentNullException>(()=> new ItemGroupClient(null, _mockPayloadResolver.Object));
        }

        #endregion

        #region ListItemGroups Tests

        /// <summary>
        /// Test ListItemGroups with an object that resolves to a query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListItemGroups_Success_With_Query_String()
        {

            Assert.Fail();
            
        }

        /// <summary>
        /// Test ListItemGroups with an object that resolves to an empty query string with no exceptions thrown
        /// </summary>
        [Test]
        public void ListItemGroups_Success_Empty_Query_String()
        {
            Assert.Fail();
        }

        #endregion

        #region CreateItemGroup
        
        /// <summary>
        /// Test CreateItemGroup that executes successfully end-to-end
        /// </summary>
        [Test]
        public void CreateItemGroup_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test CreateItemGroup throws an exception if no item group is provided
        /// </summary>
        [Test]
        public void CreateItemGroup_Null_Request()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(null));
        }

        /// <summary>
        /// <see cref="CreateItemGroupRequest.ItemGroup"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Null_ItemGroup()
        {

            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                   

                }
            };
            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="SubCreateItemGroupRequest.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Name()
        {

            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = null,
                    SortlyId = "id",
                    Attributes = new ItemGroupAttribute[]
                    {
                        new ItemGroupAttribute {
                            Id = Guid.NewGuid(),
                            Name = "name",
                            Order = 2
                        }
                    }
                }
            };
            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="SubCreateItemGroupRequest.Attributes"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Attributes()
        {
            
            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = "name",
                    SortlyId = "id",
                    Attributes = null
                }
            };
            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Attribute_Name()
        {
            
            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = "name",
                    SortlyId = "id",
                    Attributes = new ItemGroupAttribute[]
                    {
                        new ItemGroupAttribute {
                            Id = Guid.NewGuid(),
                            Name = null,
                            Order = 2,
                            Options = new ItemGroupAttributeOption[]
                            {
                                new ItemGroupAttributeOption
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "name3",
                                    Order = 4
                                }
                            }
                        }
                    }
                }
            };
            
            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Order"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Attribute_Order()
        {
           
            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = "name",
                    SortlyId = "id",
                    Attributes = new ItemGroupAttribute[]
                    {
                        new ItemGroupAttribute {
                            Id = Guid.NewGuid(),
                            Name = "name1",
                            Order = null,
                            Options = new ItemGroupAttributeOption[]
                            {
                                new ItemGroupAttributeOption
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "name3",
                                    Order = 4
                                }
                            }
                        }
                    }
                }
            };

            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Options"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Attribute_Options()
        {
            
            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = "name",
                    SortlyId = "id",
                    Attributes = new ItemGroupAttribute[]
                    {
                        new ItemGroupAttribute {
                            Id = Guid.NewGuid(),
                            Name = "name1",
                            Order = 2,
                            Options = new ItemGroupAttributeOption[]
                            {
                               
                            }
                        }
                    }
                }
            };

            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="ItemGroupAttributeOption.Name"/> fails validation and throws an exception
        /// </summary>

        [Test]
        public void CreateItemGroup_Validation_Failure_Attribute_Option_Name()
        {
           
            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = "name",
                    SortlyId = "id",
                    Attributes = new ItemGroupAttribute[]
                    {
                        new ItemGroupAttribute {
                            Id = Guid.NewGuid(),
                            Name = "name1",
                            Order = 2,
                            Options = new ItemGroupAttributeOption[]
                            {
                                new ItemGroupAttributeOption
                                {
                                    Id = Guid.NewGuid(),
                                    Name = null,
                                    Order = 4
                                }
                            }
                        }
                    }
                }
            };

            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        /// <summary>
        /// <see cref="ItemGroupAttributeOption.Order"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void CreateItemGroup_Validation_Failure_Attribute_Option_Order()
        {
           
            var request = new CreateItemGroupRequest()
            {
                ItemGroup = new SubCreateItemGroupRequest()
                {
                    Name = "name",
                    SortlyId = "id",
                    Attributes = new ItemGroupAttribute[]
                    {
                        new ItemGroupAttribute {
                            Id = Guid.NewGuid(),
                            Name = "name1",
                            Order = 2,
                            Options = new ItemGroupAttributeOption[]
                            {
                                new ItemGroupAttributeOption
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "name3",
                                    Order = null
                                }
                            }
                        }
                    }
                }
            };

            Assert.ThrowsAsync<SortlyValidationException>(() => new ItemGroupClient(_mockApi.Object, _mockPayloadResolver.Object).CreateItemGroup(request));
        }

        #endregion

        #region UpdateItemGroup

        /// <summary>
        /// Test UpdateItemGroup that executes successfully end-to-end
        /// </summary>
        [Test]
        public void UpdateItemGroup_Success()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test UpdateItemGroup throws an exception if no item group is provided
        /// </summary>
        [Test]
        public void UpdateItemGroup_Null_Request()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Name()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="SubCreateItemGroupRequest.Attributes"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Attributes()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Attribute_Name()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Order"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Attribute_Order()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="ItemGroupAttribute.Options"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Attribute_Options()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="ItemGroupAttributeOption.Name"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Attribute_Option_Name()
        {
            Assert.Fail();
        }

        /// <summary>
        /// <see cref="ItemGroupAttributeOption.Order"/> fails validation and throws an exception
        /// </summary>
        [Test]
        public void UpdateItemGroup_Validation_Failure_Attribute_Option_Order()
        {
            Assert.Fail();
        }

        #endregion

        #region GetItemGroup Tests

        /// <summary>
        /// Test GetItemGroup with an object that resolves to a query string with no exceptions thrown
        /// </summary>
        [Test]
        public void GetItemGroup_Success_With_Query_String()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Test GetItemGroup with an object that resolves to an empty query string with no exceptions thrown
        /// </summary>
        [Test]
        public void GetItemGroup_Success_Without_Query_String()
        {
            Assert.Fail();
        }

        #endregion


        #region DeleteItemGroup Tests

        /// <summary>
        /// Test DeleteItemGroup successfully executes without exceptions thrown
        /// </summary>
        [Test]
        public void DeleteItemGroup_Success()
        {
            Assert.Fail();
        }

        #endregion
       
    }
}
