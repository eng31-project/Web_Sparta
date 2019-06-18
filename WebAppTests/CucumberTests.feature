Feature: CucumberTests
	When I enter my login credentials I should be redirected to the login page

@mytag
Scenario: Retrieve the contact page
	Given I am at the login page
	And I have correctly entered my credentials
	When I press Login
	Then the result should be the User/Index page