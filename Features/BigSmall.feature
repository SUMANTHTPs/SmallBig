Feature: Bigsmall
	To test the functionalities of the given website
	www.bigsmall.in

Background: Website initialisation
	Given I Intialize the browser
	And navigate to the URL

Scenario: Get the title of that page
	Given I am in homepage
	Then get the title of that page

Scenario Outline: Login with valid credential
	Given I click on signup
	And enter <email> and <password>
	When click on sign in button
	Then It should check for robot or man

	Examples:
		| email                   | password |
		| sumanthsumu17@gmail.com | 12345678 |

Scenario Outline: Login with invalid credential
	Given I click on signup
	And enter <email> and <password>
	When click on sign in button
	Then It should check for robot or man

	#Then It should display Incorrect email or password.
	Examples:
		| email                   | password |
		| sumanthsumu17@gmail.com | abs      |

Scenario: Get the price
	Given I click on search bar
	And search harry potter in the search bar
	When I click the first product
	Then I should get the price of that product

Scenario:Check pincode in gift card for COD
	Given I click on the gift card
	When I enter pincode 577225
	Then check the COD availibility

Scenario: Select Rakhi in footer
	Given I click on rakhi
	Then It should navigate to the rakhi page

Scenario: Gift for mens
	Given I hover on gifts dropdowns
	And select gift for guys
	Then It should display Best Gifts For Guys, Men In India

Scenario: Display top 50 gifts
	Given I click on top 50
	Then it should display top 50 items

Scenario: Get Descriptions
	Given I click on search bar
	And search harry potter in the search bar
	When I click the first product
	Then I get description

Scenario: Add To Wishlist
	Given I click on search bar
	And search harry potter in the search bar
	When I click the first product
	And I click on wishlist
	Then I navigate to wishlist and get the title of the product in wishlist