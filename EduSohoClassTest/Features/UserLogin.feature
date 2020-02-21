Feature: EduSoho User Login
	In order to view the lessons of SohoEDU
	As a user
	I want to login 


@auto
Scenario: should sccuess to login without RememberMe
	Given I am in homepage
	And I click login buton and jump to login page
	When I enter "<username>" username and "<password>" password to login
	Then I can see avatar image on the right top of the home page
	Examples: 
	| username | password |
	| test001  | Test1234 |

@auto
Scenario: should sccuess to login with RememberMe
	Given I am in homepage
	And I click login buton and jump to login page
	When I click remember me checkbox
	And I enter "<username>" username and "<password>" password to login
	Then I can see avatar image on the right top of the home page
	Examples: 
	| username | password |
	| test001  | Test1234 |

@auto
Scenario: should fail to login with invalid credential
	Given I am in homepage
	And I click login buton and jump to login page
	When I enter "<username>" username and "<password>" password to login
	Then I can see "用户名或密码错误" on the login page
	Examples: 
	| username | password |
	| test001  | invalidPWD |

	#@auto
#Scenario: UserLogin1
#	Given I am in homepage
#	And I click login buton and jump to login page
#	When I enter "<username>" username and "<password>" password to login and jump to home page
#	Then I can click the 更多课程 and jump to course page
#	And I can click the 产品介绍 and view the productlist
#	Examples: 
#	| username | password |
#	| test001  | Test1234 |