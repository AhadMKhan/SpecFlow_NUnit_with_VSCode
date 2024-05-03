
Feature: Amazon Shopping
    As an unregistered user
    I want to search for a product, add it to the cart, and validate the cart contents

    Scenario Outline: Add product to cart
        Given I am on the Amazon website
        When I search for "<Product>"
        And I add the corresponding item to the cart
        Then I should see the "<Product>" and amount "<Amount>" in the cart

        Examples:
        | Product                                          | Amount  |
        | TP-Link Tri-Band BE9300 WiFi 7 Router Archer BE550 | $299.99 |