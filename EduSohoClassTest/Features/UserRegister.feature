Feature: UserRegister
	In order to user more functions of the system
	As a user
	I want to register in the system


@negative
Scenario: should give correct message for invalid info entered in register page
	Given I am in register page
	When enter "<inputValue>"inputValue to the "<fieldName>" fieldName to the form and press Enter key
	And click register button
	Then there should be "<msg>"msg shown below  "<fieldName>" fieldName
Examples: 
| fieldName   | inputValue | msg                    |
| email       |            | 请输入邮箱                  |
| email       | aa         | 请输入有效的电子邮件地址           |
| email       | aa@        | 请输入有效的电子邮件地址           |
| email       | aa@cc      | 请输入有效的电子邮件地址           |
| email       | aa@cc.     | 请输入有效的电子邮件地址           |
| email       | aa@cc.cc.  | 请输入有效的电子邮件地址           |
| username    |            | 请输入用户名                 |
| username    | abc        | 字符长度必须大于等于4，一个中文字算2个字符 |
| username    | 用c         | 字符长度必须大于等于4，一个中文字算2个字符 |
| password    |            | 请输入密码                  |
| password    | abcd       | 最少需要输入 5 个字符           |
| captchaCode |            | 请输入验证码                 |
| captchaCode | vvvv       | 验证码错误                  |
| userterm    | false      | 勾选同意此服务协议，才能继续注册       | 

#
#@negative
#Scenario: should give correct message for invalid info entered in register page
#	Given I am in register page
#	When enter the "<email>"email,"<username>"usrname,"<password>"password,"<captchaCode>"captchaCode,<userterm> userterm  to the form
#	And click register button
#	Then there should be "<msg>"msg shown in the "<msgLabel>" msgLabel
#Examples: 
#| email		| username | password	| captchaCode	|userterm| msgLabel		| msg	|
#|			| tester   | pwd7890	| abcd			|true	| email			| 请输入邮箱 |
#| aa@qq.com	|		   | pwd7890	| abcd			|true	| username		| 请输入用户名 |
#| aa@qq.com	| tester   |			| abcd			|true	| password		| 请输入密码 |
#| aa@qq.com	| tester   | pwd7890	|				|true	| captchaCode	| 请输入验证码 |
#|aa@qq.com	| tester   | pwd7890	| abcd          |true	| captchaCode	| 验证码错误 |
#|aaa		| tester   | pwd7890	| abcd          |true	| email			| 请输入有效的电子邮件地址 |
#|aaa@		| tester   | pwd7890	| abcd          |true	| email			| 请输入有效的电子邮件地址 |
#|aaa@bb		| tester   | pwd7890	| abcd          |true	| email			| 请输入有效的电子邮件地址 |
#|aaa@bb.	| tester   | pwd7890	| abcd          |true	| email			| 请输入有效的电子邮件地址 |
#|aaa@bb.com.| tester   | pwd7890	| abcd          |true	| email			| 请输入有效的电子邮件地址 |
#|aa@qq.com	| tester   | 1234		| abcd          |true	| captchaCode	| 验证码错误 |
#|aa@qq.com	| u12	   | pwd7890	| abcd          |true	| username		| 字符长度必须大于等于4，一个中文字算2个字符 |
#|aa@qq.com	| 用a	   | pwd7890	| abcd          |true	| username		| 字符长度必须大于等于4，一个中文字算2个字符 |
#|aa@qq.com	| tester   | pwd7890	| abcd          |false	| userterm		| 勾选同意此服务协议，才能继续注册 |
#
