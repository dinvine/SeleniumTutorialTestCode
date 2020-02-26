Feature: PersonalSettings
	In order to set infos of myself
	As a user
	I want to set infomations in the settings page

@negative
Scenario: Upload image for avatar
	Given I success to  enter "<username>" username and "<password>" password to log in
	And hover on the avatar and click "个人设置"
	And click on the 头像设置
	When click 上传新头像
	And select image file and upload it
	Then the avatar is updated to the new image
	Examples: 
	| username | password |
	| test001  | Test1234 |

@negative
Scenario: should give response to invalid input in personal basic info page
	Given I success to  enter "test001" username and "Test1234" password to log in
	And hover on the avatar and click "个人设置"
	And click on the 基础信息
	Then msg should be there when inputValue is entered to fieldName as table below in personal basic info page
	| fieldName		| inputValue			| msg										|
	| 真实姓名		| a123456789012345678	| 最多只能输入 18 个字符						|
	| 身份证号码		| 320508198001014880	| 请正确输入您的身份证号码					|
	|手机号码		| 29915559844			| 请输入正确的手机号							|
	| 公司			| MagicCloud Corp.      |											|
	| 职业			| Test analyst			|											|
	| 头衔			|intermediate tester so good a title i like|	最多只能输入 24 个字符|
	| 个人签名		| good better best		|											|
	| 自我介绍		| impssible is nothing	|											|
	| 个人空间		| github.com			| 地址不正确，须以http://或者https://开头。	|
	| 微博			|    wechat.com			| 地址不正确，须以http://或者https://开头。	|
	| 微信			| dinvvvvv				|											|
	| QQ			|   84745aaa			| 请输入正确的QQ号							|


	@positive
Scenario: should be able to modify personal basic info page
	Given I success to  enter "test001" username and "Test1234" password to log in
	And hover on the avatar and click "个人设置"
	And click on the 基础信息
	When msg should be there when inputValue is entered to fieldName as table below in personal basic info page
	| fieldName		| inputValue			| msg	|
	| 真实姓名		| Daniel				|		|
	| 身份证号码		| 320508198001014885	|		|
	|手机号码		| 19915559844			|		|
	| 公司			| Lyra Edu	 Corp.      |		|
	| 职业			| Test analyst			|		|
	| 头衔			|intermediate tester	|		|
	| 个人签名		| good better best		|		|
	| 自我介绍		| impssible is nothing	|		|
	| 个人空间		| http://github.com		|		|
	| 微博			|   http://weibo.com	|		|
	| 微信			| dinvvvvv				|		|
	| QQ			|   84745aaa			|		|
	And click 保存 in personal basic info page
	Then success message should show "基础信息保存成功。"