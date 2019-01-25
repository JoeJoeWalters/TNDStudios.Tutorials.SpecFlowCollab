using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TNDStudios.Tutorials.SpecFlowCollab.Tests;

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

            // Make sure any variables really are reset
            apiRequest = null;
        }

        /// <summary>
        /// After each scenario runs
        /// </summary>
        [AfterScenario]
        public void After()
        {

        }

        [Given(@"a (.*) record has been transmitted to the Api")]
        public void GivenAPersonRecordHasBeenTransmittedToTheApi(String typeString)
        {
            // What has the specflow step asked to check?
            IDomainObject objectToUse = null;
            switch (typeString)
            {
                case "Person":
                    objectToUse = testPerson; // A Person
                    break;

                case "Asset":
                    objectToUse = testAsset; // An Asset
                    break;
            }

            // Set up the fake incoming request
            apiRequest = new APIRequest<IDomainObject>()
                        {
                            Data = objectToUse
                        };
        }

        [Given(@"the processor passes the basic validation of that record")]
        public void GivenTheProcessorPassesTheBasicValidationOfThatRecord()
        {
            Assert.True(apiRequest.Data.IsValid);
        }

        [When(@"the request is processed by the routing logic")]
        public void WhenTheRequestIsProcessedByTheRoutingLogic()
        {

        }

        [Then(@"the Person record is placed on the Person service bus")]
        public void ThenThePersonRecordIsPlacedOnThePersonServiceBus()
        {

        }

        [Then(@"the Assert record is placed on the Asset service bus")]
        public void ThenTheAssertRecordIsPlacedOnTheAssetServiceBus()
        {

        }
    }
}
