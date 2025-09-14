Feature: Pet 

#POST /pet – Add a new pet to the store
  Scenario: Successfully add a new pet to the store
    Given I am a "authorized" user
    When I send a POST request to "/pet" with the following data:
      | name | type | photoUrls | tag   | status    |
      | DogWG  | Dog  | https://www.zooplus.pl/magazyn/wp-content/uploads/2019/06/pies-pompon-1.jpeg | dogwg | available |
    Then the response status code should be 200
    And the response body should contain the name "DogWG"
    And the pet status should be "available"

#PUT /pet – Update an existing pet
   Scenario: Successfully update an existing pet
    Given I have a pet with ID "4"
    When I send a PUT request to "/pet" with the following data:
      | id   | name  | type  | status    |
      | 4 | Dog   | Dog   | sold      |
    Then the response status code should be 200
    And the response body should contain the pet ID "4"
    And the pet status should be "sold"

#GET /pet/findByStatus – Finds Pets by status
    Scenario: Retrieve pets with the status "available"
    Given I am a "guest" user
    When I send a GET request to method "findByStatus" and parm "available"
    Then the response status code should be 200
    And the response body should contain a list of pets with status "available"

#GET /pet/findByTags – Finds Pets by tags
   Scenario: Retrieve pets with the tag "cute"
    Given I am a "guest" user
    When I send a GET request to method "findByTags" and parm "cute"
    Then the response status code should be 200
    And the response body should contain a list of pets with the tag "cute"

# GET /pet/{petId} – Find pet by ID
  Scenario: Retrieve a pet's details by its ID
    Given I have a pet with ID "5"
    When I send a GET request to method "findByID" and parm "5"
    Then the response status code should be 200
    And the response body should contain the pet ID "5"
    And the pet name should not be empty

# POST /pet/{petId} – Updates a pet in the store with form data
  Scenario: Successfully update a pet with form data
    Given I have a pet with ID "1234"
    When I send a POST request to "/pet/1234" with form data:
      | name    | type  | status    |
      | Dog     | Dog   | sold      |
    Then the response status code should be 200
    And the response body should confirm that the pet ID "1234" has been updated

# DELETE /pet/{petId} – Deletes a pet
  Scenario: Successfully delete a pet from the store
    Given I have a pet with ID "1234"
    When I send a DELETE request to "/pet/1234"
    Then the response status code should be 200
    And the response body should confirm that the pet was deleted

# POST /pet/{petId}/uploadImage – Uploads an image
  Scenario: Successfully upload an image for a pet
    Given I have a pet with ID "1234"
    When I send a POST request to "/pet/1234/uploadImage" with an image file
    Then the response status code should be 200
    And the response body should contain the pet ID "1234"
    And the image should be successfully uploaded