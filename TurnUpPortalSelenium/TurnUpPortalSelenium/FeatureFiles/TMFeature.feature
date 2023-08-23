Feature: TMFeature

I would like to Create,Edit and Delete Time and Materials records
so that I can manage Time and Materials record 

@tag1
Scenario: Create Time record with valid input details
	Given I logged into TurnUp portal successfully
	And I navigate to Time and Materials page
	When I create a new Time record
	Then the record should be created successfully
