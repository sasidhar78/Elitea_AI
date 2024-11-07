Feature: SauceDemo Login Functionality

  Scenario Outline: Login with different user types
    Given I am on the SauceDemo login page
    When I enter "<username>" and "<password>"
    And I click the login button
    Then I should be redirected to the product page

    Examples:
      | username               | password     |
      | standard_user          | secret_sauce |
      | problem_user           | secret_sauce |
      | performance_glitch_user| secret_sauce |