using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SwaggerPetstoreOpenAPIRestSharpProject.API.API;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.RequestAndResponse.Pet;
using System.Net;

namespace SwaggerPetstoreOpenAPIRestSharpProject.SpecFlow.StepDefinitions
{
    [Binding]
    public class PetStepDefinitions
    {
        private PetReqResponse _petReqResponse;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        private HttpStatusCode _statusCode;
        APIClientPet api;

        public PetStepDefinitions(PetReqResponse petReqResponse,  ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _petReqResponse = petReqResponse;
            api = new APIClientPet();
        }

        [Given(@"I am an authorized user")]
        public void GivenIAmAnAuthorizedUser()
        {
            
        }
      //  When I send a POST request to "/pet" with the following data:
      //| name    | type  | status    |
      //| Dog     | Dog   | available |

        [When(@"I send a POST request to ""([^""]*)"" with the following data:")]
        public async Task WhenISendAPOSTRequestToWithTheFollowingData(string p0, Table table)
        {
            _petReqResponse = new PetReqResponse
            {
                Name = table.Rows[0]["name"],
                Category = new Category
                {
                    Name = table.Rows[0]["type"]
                },
                Status = table.Rows[0]["status"],
                PhotoUrls = new string[] { table.Rows[0]["photoUrls"] },
                Tags = new Tag[]
                {
                    new Tag
                    {
                        Name = "cute"
                    }
                }
            };
            // Send request to the API
            _response = await api.CreatePet(_petReqResponse);

        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int p0)
        {
            _statusCode = _response.StatusCode;
            var code = (int)_statusCode;
            Assert.AreEqual(p0, code);
        }

        [Then(@"the response body should contain the name ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainTheName(string dogName)
        {
            var expectedName = dogName;
            // Deserialize response JSON to an object
            var responseBody = JsonConvert.DeserializeObject<PetReqResponse>(_response.Content);
            // Validate that the response contains the expected pet name
            Assert.AreEqual(expectedName, responseBody.Name);
        }

        [Then(@"the pet status should be ""([^""]*)""")]
        public void ThenThePetStatusShouldBe(string available)
        {
            var expectedAvailable = available;
            // Deserialize response JSON to an object
            var responseBody = JsonConvert.DeserializeObject<PetReqResponse>(_response.Content);
            // Validate that the response contains the expected pet name
            Assert.AreEqual(expectedAvailable, responseBody.Status);
        }

        [Given(@"I have a pet with ID ""([^""]*)""")]
        public void GivenIHaveAPetWithID(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I send a PUT request to ""([^""]*)"" with the following data:")]
        public void WhenISendAPUTRequestToWithTheFollowingData(string p0, Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should contain the pet ID ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainThePetID(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I am a guest user")]
        public void GivenIAmAGuestUser()
        {
            throw new PendingStepException();
        }

        [When(@"I send a GET request to ""([^""]*)""")]
        public void WhenISendAGETRequestTo(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should contain a list of pets with status ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainAListOfPetsWithStatus(string available)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should contain a list of pets with the tag ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainAListOfPetsWithTheTag(string cute)
        {
            throw new PendingStepException();
        }

        [Then(@"the pet name should not be empty")]
        public void ThenThePetNameShouldNotBeEmpty()
        {
            throw new PendingStepException();
        }

        [When(@"I send a POST request to ""([^""]*)"" with form data:")]
        public void WhenISendAPOSTRequestToWithFormData(string p0, Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should confirm that the pet ID ""([^""]*)"" has been updated")]
        public void ThenTheResponseBodyShouldConfirmThatThePetIDHasBeenUpdated(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I send a DELETE request to ""([^""]*)""")]
        public void WhenISendADELETERequestTo(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should confirm that the pet was deleted")]
        public void ThenTheResponseBodyShouldConfirmThatThePetWasDeleted()
        {
            throw new PendingStepException();
        }

        [When(@"I send a POST request to ""([^""]*)"" with an image file")]
        public void WhenISendAPOSTRequestToWithAnImageFile(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the image should be successfully uploaded")]
        public void ThenTheImageShouldBeSuccessfullyUploaded()
        {
            throw new PendingStepException();
        }
    }
}
