Feature: Credentials
	In order to log in
	As a user
	I want to log in

@mytag
Scenario: Log in
	Given I have entered 'sachielsc@gmail.com' into the userName field
	And I have entered 'scsgdtcy3' into the passWord field
	When I press the log in button
	Then I should be able to see my account name 'sachielsc@gmail.com' on the home page
