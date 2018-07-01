Feature: RestApiValidation
      check if user can access the API endpoint and it's content details.

@mytag
Scenario: Successfully access the Rest API
	Given I have  access the Rest Api endpoint https://jsonplaceholder.typicode.com/Posts
	Then it should return the http reponse code OK

Scenario: Access the content and match with expected count
	Given I have  access the Rest Api endpoint https://jsonplaceholder.typicode.com/Posts
	And  retreive the content
	Then the total retreived objects count should match to 100
