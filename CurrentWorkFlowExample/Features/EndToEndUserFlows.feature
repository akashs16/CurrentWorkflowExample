Feature: EndToEndUserFlows
	In order to test the different User flows on the Reebonz Website.

@prodSgUser
@cancelItemCheckoutFromPaymentDetailsPage
Scenario Outline: The user should be able to see the correct payment options while checkout on Singapore site
	Given I am on the landing page of the <website> website
	And I sign in
	When go to a particular event and add a product to my cart
	And proceed to buy an item using <paymentMethod>
	Then the user is able to procced to the payment page with paymentType <paymentMethod>
	Examples: 
	| paymentMethod | website                    |
	| paypal        | https://www.reebonz.com.sg |
	| card          | https://www.reebonz.com.sg |

@ignore	
@prodCnUser
@cancelItemCheckoutFromPaymentDetailsPage
Scenario Outline: The user should be able to see the correct payment options while checkout on China site
	Given I am on the landing page of the <website> website
	And I sign in
	When go to a particular event and add a product to my cart
	And proceed to buy an item using <paymentMethod>
	Then the user is able to procced to the payment page with paymentType <paymentMethod>
	Examples: 
	| paymentMethod | website                 |
	| union         | https://www.reebonz.cn/ |
	| alipay        | https://www.reebonz.cn/ |