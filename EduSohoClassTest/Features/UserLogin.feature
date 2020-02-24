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

Scenario: should give correct message for invalid email entered in pwd reset page
	Given I am in homepage
	And I click login buton and jump to login page
	And click 找回密码 link
	When enter "<emailForPWDReset>"emailForPWDReset
	And click 重设密码
	Then there should be "<msg>"msg shown on  "<fieldName>" fieldName in password reset page
	Examples: 
	| emailForPWDReset | msg					| fieldName  |
	| aa.com           | 请输入有效的电子邮件地址 | invalid    |
	| aa@bb            | 请输入有效的电子邮件地址 | unexisting |
	| aa@bb.bb.        | 请输入有效的电子邮件地址 | invalid    |
	| aa@aa.com        | 该邮箱地址没有注册过帐号 | unexisting |


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