Feature: ProcessingOfAPIRequests
	In order to process incoming API requests
	As an object processor
	I want to be able to route the object requests to the correct service bus

@PersonRecordSentToApi
Scenario: Incoming Request To Save A Person Record
	Given a Person record has been transmitted to the Api
	And the processor passes the basic validation of that record
	When the request is processed by the routing logic
	Then the Person record is placed on the Person service bus

@AssetRecordSentToApi
Scenario: Incoming Request To Save An Asset Record
	Given a Asset record has been transmitted to the Api
	And the processor passes the basic validation of that record
	When the request is processed by the routing logic
	Then the Assert record is placed on the Asset service bus
