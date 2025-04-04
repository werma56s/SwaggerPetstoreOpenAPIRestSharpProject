Feature: User

# POST /user – Create user
  Scenario: Successfully create a user
    Given I am an authorized admin
    When I send a POST request to "/user" with the following data:
      | username | firstName | lastName | email               | password | phone     | userStatus |
      | johnDoe  | John      | Doe      | john.doe@email.com   | pass123  | 123456789 | 1          |
    Then the response status code should be 200
    And the response body should contain the username "johnDoe"
    And the user status should be "1"

# POST /user/createWithList – Creates list of users with given input array
  Scenario: Successfully create a list of users
    Given I am an authorized admin
    When I send a POST request to "/user/createWithList" with the following data:
      | username  | firstName | lastName | email               | password | phone     | userStatus |
      | janeDoe   | Jane      | Doe      | jane.doe@email.com   | pass123  | 987654321 | 1          |
      | samSmith  | Sam       | Smith    | sam.smith@email.com  | pass123  | 555123456 | 1          |
    Then the response status code should be 200
    And the response body should contain "2" users created
    And the users' usernames should be "janeDoe" and "samSmith"

# GET /user/login – Logs user into the system
  Scenario: Successfully log in with valid credentials
    Given I am a user with username "johnDoe" and password "pass123"
    When I send a GET request to "/user/login" with query parameters:
      | username | johnDoe |
      | password | pass123 |
    Then the response status code should be 200
    And the response body should contain a session token

# GET /user/logout – Logs out current logged in user session
  Scenario: Successfully log out a logged-in user
    Given I am a logged-in user with username "johnDoe"
    When I send a GET request to "/user/logout"
    Then the response status code should be 200
    And the response body should confirm that the user has been logged out

# GET /user/{username} – Get user by username
  Scenario: Retrieve a user by username
    Given I have a user with username "johnDoe"
    When I send a GET request to "/user/johnDoe"
    Then the response status code should be 200
    And the response body should contain the username "johnDoe"
    And the user status should be "1"

# PUT /user/{username} – Update user resource
  Scenario: Successfully update user information
    Given I have a user with username "johnDoe"
    When I send a PUT request to "/user/johnDoe" with the following data:
      | firstName | JohnUpdated |
      | lastName  | DoeUpdated |
      | email     | john.updated@email.com |
    Then the response status code should be 200
    And the response body should contain the updated username "johnDoe"
    And the user email should be "john.updated@email.com"

# DELETE /user/{username} – Delete user resource
  Scenario: Successfully delete a user
    Given I have a user with username "johnDoe"
    When I send a DELETE request to "/user/johnDoe"
    Then the response status code should be 200
    And the response body should confirm that the user "johnDoe" was deleted
