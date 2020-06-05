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
	And I enter "<CategoryName>", "<TitleKeyword>", "<Property>", "<PublishStatus>" to the conditions 
	And I click search button
	Then results table should comform to the  "<CategoryName>", "<TitleKeyword>", "<PropertyShow>", "<PublishStatus>" conditions.
Examples: 
| CategoryName | TitleKeyword	| Property	|PropertyShow| PublishStatus	|
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
	When I  select "<action>" action  to the first  "<PublishStatus>" publish value record and click the right checkbox
	Then the 状态 colname of the checked record should change to "<NewStatus>" value
Examples: 
| PublishStatus	| action	| NewStatus	|
| 已发布	|	取消发布	|未发布	|
| 未发布	|	发布		|已发布	|


@positive
Scenario: Should be able to add a category to articles
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	And I am in admin article page
	And I click linktext "栏目管理"
	And I delete the article category coded "<CategoryCode>" 
	When I click 添加栏目 button
	And enter "<CategoryName>"," <CategoryCode>","<ParentCategory>","<SEOTitle>","<SEOKeyword>","<SEODescription>","<Enable>" to the article category add page
	And click 添加 on  article category add page
	Then new "<CategoryCode>" caterory code should be found in the article category page
Examples: 
| CategoryName	| CategoryCode	| ParentCategory| SEOTitle		|SEOKeyword	| SEODescription			| Enable|
| nz env		| environment01	| EduSoho		|good for all	|env		|new zealand env reports	|	是	|


@positive
Scenario: Should be able to modify the name of article category
	Given I success to  enter "admin" username and "5EstafeyEtre" password to log in
	And I am in admin article page
	And I click linktext "栏目管理"
	When I modify the "<CategoryName>" category name to "<NewCategoryName>" new one	
	Then  "<NewCategoryName>" new category name should be found in the article category page
Examples: 
| CategoryName	| NewCategoryName	|	
| nz env		| DanielWriteDate	|