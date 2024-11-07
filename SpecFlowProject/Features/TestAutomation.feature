Feature: Testing TestAutomation website

Background: 
	Given I am on TestAutomation Website


@RadioButton
Scenario: verify Radio Button
	When I click on "male"
	Then Radio button of male must be selected

@CheckBox
Scenario:verify check box
	When I select checkbox of "sunday"
	Then the check box must be selected

@CheckDropDown
Scenario Outline: verify dropDown
	When I select dropdown of "country" id and "<value>"
	Then DropDown must be selected as "<value>"

	Examples: 
	| value         |
	| United States |
	| Canada        |
	| Germany       |

@Alerts
Scenario:verify Alerts
	When I click on alert of id "alertBtn"
	And confirm the alert
	Then Alert must be closed
