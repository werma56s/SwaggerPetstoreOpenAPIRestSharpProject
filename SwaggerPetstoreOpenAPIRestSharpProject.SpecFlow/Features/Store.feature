Feature: Petstore Store Inventory

# GET /store/inventory – Returns pet inventories by status
  Scenario: Retrieve pet inventory by status
    Given I am a guest user
    When I send a GET request to "/store/inventory"
    Then the response status code should be 200
    And the response body should contain a list of pet inventories by status

# POST /store/order – Place an order for a pet
  Scenario: Successfully place an order for a pet
    Given I am an authorized user
    When I send a POST request to "/store/order" with the following data:
      | petId | quantity |
      | 1234  | 1        |
    Then the response status code should be 200
    And the response body should contain the order ID
    And the order status should be "placed"

# GET /store/order/{orderId} – Find purchase order by ID
  Scenario: Retrieve purchase order details by ID
    Given I have a valid order ID "5678"
    When I send a GET request to "/store/order/5678"
    Then the response status code should be 200
    And the response body should contain the order ID "5678"
    And the order status should be "placed"

# DELETE /store/order/{orderId} – Delete purchase order by identifier
  Scenario: Successfully delete a purchase order by ID
    Given I have an order ID "5678"
    When I send a DELETE request to "/store/order/5678"
    Then the response status code should be 200
    And the response body should confirm that the order was deleted
