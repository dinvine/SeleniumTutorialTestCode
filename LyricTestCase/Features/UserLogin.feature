Feature: UserLogin
	In order to view the lessons of Lyric
	As a user
	I want to login 

@auto
Scenario: UserLogin
	Given I am in homepage
	And I click login buton and jump to login page
	When I enter "<username>" username and "<password>" password to login and jump to home page
	Then I can click the 更多课程 and jump to course page
	And I can click the 产品介绍 and view the productlist
	Examples: 
	| username | password |
	| test001  | Test1234 |