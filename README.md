# Pet Store API - Resharp & SpecFlow

## Description

This project is based on the OpenAPI 3.0 specification and implements an API server for a pet store using Resharp and SpecFlow technologies.

## Technologies
- **C# / .NET** - API implementation
- **Resharp** - Enhanced code analysis and refactoring
- **SpecFlow** - API testing using BDD (Behavior-Driven Development)
- **Swagger (OpenAPI 3.0)** - API definition and documentation

## Installation and Running

1. **Clone the repository**
   ```sh
   git clone https://github.com/your-repository.git
   cd your-repository
   ```

2. **Install dependencies**
   Ensure that you have .NET SDK installed along with the required NuGet packages:
   ```sh
   dotnet restore
   ```

3. **Run the API server**
   ```sh
   dotnet run
   ```
   The API will be available at: `http://localhost:5000/swagger`

4. **Run SpecFlow tests**
   ```sh
   dotnet test
   ```

## Project Structure

### `SwaggerPetstoreOpenAPIRestSharpProject.API`
Contains API client implementations for server communication. The main folders include:
- **API** – Client classes for interacting with API resources (`APIClientPet`, `APIClientStore`, `APIClientUser`).
- **Endpoints** – API endpoint definitions.
- **Interface** – API client interfaces (`IAPIClientPet`, `IAPIClientStore`, `IAPIClientUser`).

### `SwaggerPetstoreOpenAPIRestSharpProject.MODELS`
Contains data models used in the API:
- **Enums** – Enum definitions (`FindByStatus`).
- **Request** – Request models (`UpdatesAPetInStoreReq`, `UploadsAnImageReq`).
- **RequestAndResponse** – Data structures for requests and responses, categorized into (`Pet`, `Store`, `User`).
- **Response** – Response models for various resources.

### `SwaggerPetstoreOpenAPIRestSharpProjectSpecFlow`
Handles API testing with SpecFlow:
- **Dependencies** – Test dependencies.
- **Drivers** – Helper classes for API interactions in tests.
- **Features** – `.feature` files defining test scenarios (`Pet.feature`).
- **StepDefinitions** – Implementations of test steps (`PetStepDefinitions.cs`).
- **Support** – Configuration and utility files (`ImplicitUsings.cs`).

## API Testing
SpecFlow test scenarios are defined in the `Features` folder. Example scenario:
```gherkin
Feature: Pet Store API

Scenario: Retrieve a list of pets
   Given the API is available
   When I send a GET request to "/pets"
   Then I receive a 200 response code
   And the pet list is not empty
```
