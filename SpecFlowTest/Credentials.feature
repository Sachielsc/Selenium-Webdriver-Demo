Feature: Credentials
	In order to log in
	As an user
	I want to be able to log in

@mytag
Scenario: Enter username and password to log in
	Given I have entered "sachielsc@gmail.com" into the userName field
	And I also have entered "scsgdtcy3" into the passWord field
	When I press add the log in button
	Then I should enter the home page with my account logged in
