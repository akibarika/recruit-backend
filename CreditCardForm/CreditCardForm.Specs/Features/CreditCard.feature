Feature: CreditCard

Scenario: Get all cards
Given cards pre-loaded
When get all cards
Then should have 3 cards