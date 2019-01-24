using System;
using TechTalk.SpecFlow;

namespace TNDStudios.Tutorials.SpecFlowCollab.SpecFlow.Specifications.ApiRequests
{
    [Binding]
    [Scope(Feature= "ProcessingOfAPIRequests")]
    public class ProcessingOfAPIRequestsSteps
    {
        [Given(@"a Person record has been transmitted to the Api")]
        public void GivenAPersonRecordHasBeenTransmittedToTheApi()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the processor passes the basic validation of that record")]
        public void GivenTheProcessorPassesTheBasicValidationOfThatRecord()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a Asset record has been transmitted to the Api")]
        public void GivenAAssetRecordHasBeenTransmittedToTheApi()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the request is processed by the routing logic")]
        public void WhenTheRequestIsProcessedByTheRoutingLogic()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Person record is placed on the Person service bus")]
        public void ThenThePersonRecordIsPlacedOnThePersonServiceBus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Assert record is placed on the Asset service bus")]
        public void ThenTheAssertRecordIsPlacedOnTheAssetServiceBus()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
