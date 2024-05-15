@Demo
Feature: Tech Interview Challenge Solution

This is the BDD Cucumber feature file for the solution

@Demo-A
Scenario: Successful Login with Valid Credentials
	Given I am on the SauceDemo login page
	When I enter Username as "standard_user" and Password as "secret_sauce"
	When I click on the Login button
	Then I should see redirected to the home page

@Demo-B
Scenario: Failed Login with Locked User
  Given I am on the SauceDemo login page
  When I enter Username as "locked_out_user" and Password as "secret_sauce"
  Then I click on the Login button
  Then I should get an error message indicating the user is locked

@Demo-AB
Scenario Outline: Login with multiple sets of credentials
  Given I am on the SauceDemo login page
  When I enter Username as <username> and Password as <password>
  Then I click on the Login button
  Then I should see <expected_result>

  Examples:
    | username          | password       | expected_result                              |
    | "standard_user"   | "secret_sauce" | redirected to the home page                  |
    | "locked_out_user" | "secret_sauce" | error message indicating the user is locked  |
    | "invalid_user"    | "secret_sauce" | error message indicating invalid credentials |

@Demo-C
Scenario: Happy Path Workflow
  Given I login to the SauceDemo website with valid credentials
  When I add "Sauce Labs Bike Light" to the cart from the Products page
  Then I click on the cart icon on Products Page
  When I click on "Checkout" on the Cart page
  Then I fill the checkout information with random data
  Then I click on continue button on checkout page
  Then I click on Finish on checkout overview page
  Then I click on menu icon on top left of the header
  Then I click on "Logout" button on the displayed menu

@Demo-D
Scenario: Multiple Scenarios Workflow
  Given I login to the SauceDemo website with valid credentials
  When I change the Product Sort to "Price (low to high)" on the Products page
  Then Verify the displayed name on the sort filter is "Price (low to high)"
  Then Verify prices from products are in ascending order
  When I add "Sauce Labs Fleece Jacket" to the cart from the Products page
  When I add "Sauce Labs Onesie" to the cart from the Products page
  Then Verify the Remove button is enabled for product "Sauce Labs Fleece Jacket"
  Then Verify the Remove button is enabled for product "Sauce Labs Onesie"
  Then I save the price of product "Sauce Labs Fleece Jacket" from Product page
  Then I save the price of product "Sauce Labs Onesie" from Product page
  Then Verify the value from cart is "2"
  Then I click on the cart icon on Products Page
  Then I save the price of product "Sauce Labs Fleece Jacket" from Cart page
  Then I save the price of product "Sauce Labs Onesie" from Cart page
  Then Verify prices captured from Products page are the same as Cart page
  Then I remove the product "Sauce Labs Onesie" on the Cart page
  Then I capture the quantity of items added to cart from "Sauce Labs Fleece Jacket" on the Cart page
  Then I capture the value of cart from the Cart page
  Then Verify quantity and value are the same as captured on Cart page
  When I click on "Checkout" on the Cart page
  Then I fill the checkout information with random data
  Then I click on continue button on checkout page
  Then Verify item total is same first product price captured
  Then I click on Finish on checkout overview page
  Then Capture message "Thank you for your order!" from checkout complete page
  Then I click on menu icon on top left of the header
  Then I click on "Logout" button on the displayed menu
