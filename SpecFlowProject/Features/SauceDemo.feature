
Feature: Verify Login Page

when I enter username and password I must enter into sauceDemo

Background: 
	Given I am on SauceDemo website login page

@VerifyvalidCredential
Scenario: verify login page with correct credential
	When I enter "standard_user" and "secret_sauce"
	And I click on login button
	Then I must enter into SauceDemo website

@VerifyInvalidCredential
Scenario:verify login page with Incorrect credential
	When I enter "standard_user1" and "secret_sauce1"
	And I click on login button
	Then I should not enter into SauceDemo website

@VerifyCart
Scenario:verify wheather item is going to cart or not
	When I enter "standard_user" and "secret_sauce"  
	And I click on login button
	And I select the DropDown by text "Price (low to high)"
	And Click on the first product
	And I click Add to cart
	Then element must be visible in cart


@VerifyCredentials
Scenario Outline:verify Credentials
	When I enter username and password as "<username>" and "<password>"
	And I click on login button
	Then I must enter into SauceDemo website
	Examples:
			|username |password |
			|standard_user |secret_sauce |
			|problem_user |secret_sauce |
			|performance_glitch_user |secret_sauce |

@verifyValidCredentials
@DataSource:../TestData/Data.csv
Scenario Outline:verify valid Credentials
	When I enter username and password as "<username>" and "<password>"
	And I click on login button
	Then I must enter into SauceDemo website

@verifyInvalidCredentials
@DataSource:../TestData/InvalidData.csv
Scenario Outline:verify Invalid Credential
	When I enter username and password as "<username>" and "<password>"
	And I click on login button
	And I should take the Screenshot
	Then I should not enter into SauceDemo website





