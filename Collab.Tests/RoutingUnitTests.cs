using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using TNDStudios.Tutorials.SpecFlowCollab;

namespace TNDStudios.Tutorials.SpecFlowCollab.Tests
{
    [TestFixture]
    public class RoutingUnitTests
    {
        [Theory]
        [TestCase(null)]
        public void Is_Object_Valid(IAPIRequest<IDomainObject> request)
        {
            // Arrange
            // Is the incoming request null? I.E. It was called from a unit test runner 
            // directly and not Specflow etc.
            request = (request == null) ?
                        new APIRequest<IDomainObject>()
                        {
                            Data = new Person()
                            {
                                Id = Guid.NewGuid(),
                                Name = "New Name",
                                Description = "New Description"
                            }
                        } : request;

            // Act
            Boolean valid = request.Data.IsValid;

            // Assert
            Assert.True(valid);
        }

        [Theory]
        [TestCase(null, null)]
        public void Recieve_Api_Request_Of_Given_Type(IAPIRequest<IDomainObject> request, Type type)
        {
            // Arrange
            // Is the incoming request null? I.E. It was called from a unit test runner 
            // directly and not Specflow etc.
            type = (type == null) ? typeof(Person) : type;
            request = (request == null) ? 
                        new APIRequest<IDomainObject>()
                        {
                            Data = new Person()
                            {
                                Id = Guid.NewGuid(),
                                Name = "New Name",
                                Description = "New Description"
                            }
                        } : request;

            // Act
            Boolean result = request.Data != null;
            Type resultType = request.Data.GetType();

            // Assert
            Assert.True(result);
            Assert.AreEqual(type, resultType);
        }

        [Theory]
        [TestCase(null, null)]
        public void Saved_To_Service_Bus(
            IAPIRequest<IDomainObject> request, 
            IServiceBusHandler<IDomainObject> serviceBus)
        {
            // Arrange
            request = (request == null) ?
                new APIRequest<IDomainObject>()
                {
                    Data = new Person()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Name",
                        Description = "Test Description"
                    }
                } : request;

            serviceBus = (serviceBus == null) ?
                new ServiceBusHandler<IDomainObject>() {}
                : serviceBus;

            // Act
            Int32 result = serviceBus.SaveObjects(
                new List<IDomainObject>()
                {
                    request.Data
                });

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
