Feature: LoginToTheWebSite
	check if user can login to the application https://www.nopcommerce.com/

@mytag
Scenario: Login as registered user
	Given I navigate to application
	And I enter username and password
		| UserName | Password |
		| jophyjosephm | test123 |
	And I click login
	Then I should see user logged in to the application
		