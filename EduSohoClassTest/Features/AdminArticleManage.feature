Feature: AdminArticleManage
	In order to manage the articles
	As an admin
	I want to view and modify the status of articles

@positive
Scenario: Should be able to search articles
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	#| username	| password |
	#| admin		| 5EstafeyEtre |
	And I am in admin article page
	And I enter "<所属栏目>", "<标题关键词>", "<属性>", "<发布状态>" to the conditions 
	And I click search button
	Then results table should comform to the  "<所属栏目>", "<标题关键词>", "<属性结果>", "<发布状态>" conditions.
Examples: 
| 所属栏目 | 标题关键词	| 属性	|属性结果| 发布状态	|
| 行业资讯 |				|		|		|			|
| 行业资讯 |	MOOC		|		|		|			|
| 行业资讯 |	MOOC		|		|		|			|
| 行业资讯 |	MOOC		| 头条	|头		|			|
| 行业资讯 |	MOOC		| 头条	|头		|	已发布	|

@positive
Scenario: Should be able to modify the Publish Status of articles
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	And I am in admin article page
	And I click search button
	When I  select "<修改动作>" action  to the first  "<状态>" publish value record and click the right checkbox
	Then the 状态 colname of the checked record should change to "<新状态>" value
Examples: 
| 状态	| 修改动作	| 新状态	|
| 已发布	|	取消发布	|未发布	|
| 未发布	|	发布		|已发布	|


@positive
Scenario: Should be able to add a category to articles
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	And I am in admin article page
	And I click linktext "栏目管理"
	And I delete the article category coded "<栏目编码>" 
	When I click 添加栏目 button
	And enter "<栏目名称>"," <栏目编码>","<父栏目>","<SEO标题>","<SEO关键字>","<SEO描述>","<启用>" to the article category add page
	And click 添加 on  article category add page
	Then new "<栏目编码>" caterory code should be found in the article category page
Examples: 
| 栏目名称	| 栏目编码		| 父栏目			| SEO标题		|SEO关键字	| SEO描述					| 启用	|
| nz env	| environment01	| EduSoho		|good for all	|env		|new zealand env reports	|	是	|


@positive
Scenario: Should be able to modify the name of article category
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	And I am in admin article page
	And I click linktext "栏目管理"
	When I modify the "<栏目名称>" category name to "<new栏目名称>" new one	
	Then  "<new栏目名称>" new category name should be found in the article category page
Examples: 
| 栏目名称	| new栏目名称		|	
| nz env	| DanielWriteDate	|