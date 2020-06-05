Feature: EduSoho User Login
	In order to view the lessons of SohoEDU
	As a user
	I want to login 


@auto
Scenario: should sccuess to login without RememberMe
	Given I am in "EduSohoHomePageURL" page
	And I click login buton and jump to login page
	When I enter "<username>" username and "<password>" password to login
	Then I can see avatar image on the right top of the home page
	Examples: 
	| username | password |
	| test001  | Test1234 |

@auto
Scenario: should sccuess to login with RememberMe
	Given I am in "EduSohoHomePageURL" page
	And I click login buton and jump to login page
	When I click remember me checkbox
	And I  login with user
	| username | password |
	| test001  | Test1234 |
	Then I can see avatar image on the right top of the home page


@auto
Scenario: should fail to login with invalid credential
	Given I am in "EduSohoHomePageURL" page
	And I click login buton and jump to login page
	When I  login with user
	| username | password |
	| test001  | invalidPWD |
#	Then I can see "用户名或密码错误" on the login page
	Then I can see "用户名或密码错误" on the page


Scenario: should give correct message for invalid email entered in pwd reset page
	Given I am in "EduSohoRetrievePWDPageURL" page
	When enter "<emailForPWDReset>"emailForPWDReset
	And click 重设密码
	Then there should be "<msg>"msg shown on  "<fieldName>" fieldName in password reset page
	Examples: 
	| emailForPWDReset | msg					| fieldName  |
	| aa.com           | 请输入有效的电子邮件地址 | invalid    |
	| aa@bb            | 该邮箱地址没有注册过帐号 | unexisting |
	| aa@bb.bb.        | 请输入有效的电子邮件地址 | invalid    |
	| aa@aa.com        | 该邮箱地址没有注册过帐号 | unexisting |
