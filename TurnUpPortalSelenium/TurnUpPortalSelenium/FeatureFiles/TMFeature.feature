Feature: TMFeature

I would like to Create,Edit and Delete Time and Materials records
so that I can manage Time and Materials record 

@tag1
Scenario: Create Time record with valid input details
	Given I logged into TurnUp portal successfully
	And I navigate to Time and Materials page
	When I create a new Time record
	Then the record should be created successfully

	Scenario Outline: Edit Time record with valid input details
	Given I logged into TurnUp portal successfully
	And I navigate to Time and Materials page
	When I update '<Description>' on existing Time record
	Then the record should have an updated '<Description>'

	Examples: 
	| Description |
	| Ajay        |
	| Arjun       |
	| Ananya      |

	Scenario: Delete Time record
	Given I logged into TurnUp portal successfully
	And I navigate to Time and Materials page
	When I delete an existing Time record
	Then the record should be deleted successfully


