Feature: AdminArticleManage
	In order to manage the articles
	As an admin
	I want to view and modify the status of articles

@positive
Scenario: Should be able to search articles
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	#| username	| password |
	#| admin		| 5EstafeyEtre |
	And hover on the avatar and click "管理后台"
	And I click linktext "运营"
	When I select "<订单类型>"订单类型 in the left menue
	And I enter "<起始时间>", "<结束时间>", "<订单状态>", "<支付方式>", "<关键词类型>", "<关键词>" into the conditions 
	And I click search button
	Then there should be <结果数量> search results
Examples: 
| 订单类型 | 起始时间				| 结束时间			| 订单状态	|支付方式	| 关键词类型	| 关键词					| 结果数量	|
| 课程订单 | 2017-12-12 22:15	| 2020-12-12 22:15	|订单状态	|支付方式	|课程名称	|						| 11		|
| 课程订单 |						|					| 已付款		|支付方式	|课程名称	|						| 57		|
