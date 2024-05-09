Feature: Login

Positive and negative tests that check user logging

	Background: 
		Given open Login Page

	Scenario: Positive login
		When enter valid user name and password then click Login button
		Then Add Project button is displayed

	Scenario Outline: Negative login with empty or short password
		When enter user name 'workandreystep@gmail.com' and password '<password>' then click Login button
		Then error message is equal to '<error message>'
		Examples: 
		| password | error message                                  |
		|          | Password is required.                          |
		| 1234     | Password is too short (5 characters required). |

	Scenario Outline: Negative login with wrong user name or wrong password
		When enter user name '<user name>' and password '<password>' then click Login button
		Then top error message is equal to 'Sorry, there was a problem.'
		And login error message is equal to 'Email/Login or Password is incorrect. Please try again.'
		Examples:
		| user name                | password      |
		| workandreystep@gmail.com | WrongPassword |
		| WrongUserName            | tmsQAC0401?   |