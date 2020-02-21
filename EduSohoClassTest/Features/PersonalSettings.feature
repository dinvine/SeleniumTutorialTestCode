Feature: PersonalSettings
	In order to set infos of myself
	As a user
	I want to set infomations in the settings page

@mytag
Scenario: Upload image for avatar
	Given I success to  enter "<username>" username and "<password>" password to log in
	And hover on the avatar and click 个人设置
	And click on the 头像设置
	When click 上传新头像
	And select image file and upload it
	Then the avatar is updated to the new image
	Examples: 
	| username | password |
	| test001  | Test1234 |