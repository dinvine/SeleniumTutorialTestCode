Feature: EduSoho LogOut
	In order to get out of the system
	As a user
	I want to use logout function

@mytag
Scenario: Success to log out
	Given I success to  enter "<username>" username and "<password>" password to log in
	When hover on the avatar and click 退出登陆
	Then I should success to logout of the web
	Examples: 
	| username | password |
	| test001  | Test1234 |
