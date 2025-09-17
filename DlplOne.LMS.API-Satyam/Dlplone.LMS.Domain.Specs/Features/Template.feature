Feature: Template

temaplate service provides email templates

@template
Scenario: Template Service will give email template based on id
	Given template id will be 1
	When GetTemplateAsync will be called
	Then the returned template will be
	| Id | TemplateName | Template       |
	| 1  | Doctor Email | Dummy Template | 
	Given template id will be 2
    When  GetTemplateAsync will be called
	Then the returned template should be null
