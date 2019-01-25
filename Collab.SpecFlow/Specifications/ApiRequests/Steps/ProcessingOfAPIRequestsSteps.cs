using System;
using NUnit.Framework;
using NSubstitute;
using TechTalk.SpecFlow;
using TNDStudios.Tutorials.SpecFlowCollab.Tests;
using System.Collections.Generic;

namespace TNDStudios.Tutorials.SpecFlowCollab.SpecFlow.Specifications.ApiRequests
{
    [Binding]
    [Scope(Feature = "ProcessingOfAPIRequests")]
    public class ProcessingOfAPIRequestsSteps
    {
        /// <summary>
        /// Define any references to external unit tests
        /// </summary>
        private RoutingUnitTests routingUnitTests;

        /// <summary>
        /// Define any local variables used to store state between the scenario steps
        /// </summary>
        private IAPIRequest<IDomainObject> apiRequest;
        private IServiceBusHandler<IDomainObject> mockedServiceBus;
        private Boolean apiResult;

        /// <summary>
        /// Canned Test Data
        /// </summary>
        private Person testPerson = new Person()
        {
            Id = Guid.NewGuid(),
            Name = "New Person",
            Description = "New Person Description"
        };

        private Asset testAsset = new Asset()
        {
            Id = Guid.NewGuid(),
            Name = "New Asset",
            Description = "New Asset Description"
        };

        /// <summary>
        /// Before each scenario runs
        /// </summary>
        [BeforeScenario]
        public void Before()
        {
            // Create an instance of each test class to use
            routingUnitTests = new RoutingUnitTests();

            // Create a mocked up substitute for our service bus logic
            mockedServiceBus = Substitute.For<IServiceBusHandler<IDomainObject>>();
            mockedServiceBus
                .SaveObjects(new List<IDomainObject>() { })
                .ReturnsForAnyArgs(1);

            // Make sure any variables really are reset
            apiRequest = null; // No request
            apiResult = false; // No records saved
        }

        /// <summary>
        /// After each scenario runs
        /// </summary>
        [AfterScenario]
        public void After()
        {

        }

        /// <summary>
        /// Check the object type that specflow is telling us to use and 
        /// select the appropriate bit of canned data
        /// </summary>
        /// <param name="typeString"></param>
        [Given(@"a (.*) record has been transmitted to the Api")]
        public void GivenAPersonRecordHasBeenTransmittedToTheApi(String typeString)
        {
            // What has the specflow step asked to check?
            IDomainObject objectToUse = null;
            Type typeToCheck = null;
            switch (typeString)
            {
                case "Person":
                    objectToUse = testPerson; // A Person
                    typeToCheck = typeof(Person);
                    break;

                case "Asset":
                    objectToUse = testAsset; // An Asset
                    typeToCheck = typeof(Asset);
                    break;
            }

            // Set up the fake incoming request
            apiRequest = new APIRequest<IDomainObject>()
                        {
                            Data = objectToUse
                        };

            // Now run the unit test to see if the data was of the correct type
            routingUnitTests.Recieve_Api_Request_Of_Given_Type(apiRequest, typeToCheck);
        }

        /// <summary>
        /// Relay on the specflow step to the unit test that checks the object
        /// validity
        /// </summary>
        [Given(@"the processor passes the basic validation of that record")]
        public void GivenTheProcessorPassesTheBasicValidationOfThatRecord()
            => routingUnitTests.Is_Object_Valid(apiRequest);

        [When(@"the request is processed by the routing logic")]
        public void WhenTheRequestIsProcessedByTheRoutingLogic()
        {
            // Run the test, it should fail at stop here if it does not work
            routingUnitTests.Saved_To_Service_Bus(apiRequest, mockedServiceBus);
            
            // Mark the result as a success
            apiResult = true;
        }

        [Then(@"the (.*) record is placed on the (.*) service bus")]
        public void ThenThePersonRecordIsPlacedOnThePersonServiceBus(String objectName, String serviceBusName)
            => Assert.True(apiResult);
    }
}
