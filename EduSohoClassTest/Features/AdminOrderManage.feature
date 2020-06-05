Feature: AdminOrderManage
	In order to view the orders
	As an admin
	I want to search for the orders by particular conditions


@positive
Scenario: Should be able to search course order
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	#| username	| password |
	#| admin		| 5EstafeyEtre |
	And hover on the avatar and click "管理后台"
	And I click 订单 in admin  order manage page
	When I select "<OrderType>"订单类型 in the left menue
	And I enter "<BeginTime>", "<EndTime>", "<OrderStatus>", "<PayMethod>", "<KeywordType>", "<Keyword>" into the conditions 
	And I click search button
	Then there should be <ResultCount> search results
Examples: 
|OrderType| BeginTime			| EndTime			|OrderStatus|PayMethod	|KeywordType| Keyword				| ResultCount|
| 课程订单 | 2017-12-12 22:15	| 2020-12-12 22:15	|订单状态	|支付方式	|课程名称	|						| 12		|
| 课程订单 |						|					| 已付款		|支付方式	|课程名称	|						| 58		|
| 课程订单 |						|					|订单状态	| 支付宝		|课程名称	|						| 暂无订单记录|
| 课程订单 |						|					|订单状态	|支付方式	| 课程名称	|EduSoHo				| 19		|
| 课程订单 |						|					|订单状态	|支付方式	|课程名称	|						| 58		|


@positive
Scenario: Should be able to search class order
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	#| username	| password |
	#| admin		| 5EstafeyEtre |
	And hover on the avatar and click "管理后台"
	And I click 订单 in admin  order manage page
	When I select "<OrderType>"订单类型 in the left menue
	And I enter "<BeginTime>", "<EndTime>", "<OrderStatus>", "<PayMethod>", "<KeywordType>", "<Keyword>" into the conditions 
	And I click search button
	Then there should be <ResultCount> search results
Examples: 
|OrderType| BeginTime			| EndTime			|OrderStatus|PayMethod	|KeywordType| Keyword				|ResultCount|
| 班级订单 | 2017-12-12 22:15	| 2020-12-12 22:15	|订单状态	|支付方式	|	班级编号	|						| 1			|
| 班级订单 |						|					| 已付款		|支付方式	|	班级编号	|						| 5			|
| 班级订单 |						|					|订单状态	| 支付宝		|	班级编号	|						|暂无订单记录|
| 班级订单 |						|					|订单状态	|支付方式	| 订单号		|CR2015063016591966296	| 1			|
| 班级订单 |						|					|订单状态	|支付方式	|	班级编号	|						| 5			|