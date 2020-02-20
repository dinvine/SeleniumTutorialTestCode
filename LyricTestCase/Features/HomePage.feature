Feature: HomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Success to log out
	Given I success to  enter "<username>" username and "<password>" password to log in
	When I click 退出登陆
	Then I should success to logout of the web
	Examples: 
	| username | password |
	| test001  | Test1234 |
