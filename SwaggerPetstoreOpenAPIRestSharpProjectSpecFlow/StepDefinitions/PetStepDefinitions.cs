using Gherkin;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
using SwaggerPetstoreOpenAPIRestSharpProject.API.API;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.Enums;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.RequestAndResponse.Pet;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;

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
            _statusCode = new HttpStatusCode();
            _scenarioContext = scenarioContext;
            _petReqResponse = petReqResponse;
            api = new APIClientPet();
        }

        [Given(@"I am a ""([^""]*)"" user")]
        public void GivenIAmAUser(string role)
        {
            
        }

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
            //IDNewPet = responseBody.Id;
            // Validate that the response contains the expected pet name
            Assert.AreEqual(expectedAvailable, responseBody.Status);
        }

        int IDNewPet = 0;

        [Given(@"I have a pet with ID ""([^""]*)""")]
        public void GivenIHaveAPetWithID(string p0)
        {
            if( p0 == "last-added")
            {
                Console.WriteLine(IDNewPet);
            }
            IDNewPet = Convert.ToInt32(p0);
            Console.WriteLine(p0);
        }

        [When(@"I send a PUT request to ""([^""]*)"" with the following data:")]
        public async Task WhenISendAPUTRequestToWithTheFollowingData(string p0, Table table)
        {
                _petReqResponse.Id = IDNewPet;
                _petReqResponse.Name = table.Rows[0]["name"];
                _petReqResponse.Category = new Category
                {
                    Name = table.Rows[0]["type"]
                };
                _petReqResponse.Status = table.Rows[0]["status"];
            
            // Send request to the API
            _response = await api.UpdatePet(_petReqResponse);
        }

        [Then(@"the response body should contain the pet ID ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainThePetID(string p0)
        {
            //if (p0 == "last-added")
            //{ // Deserialize response JSON to an object
              var responseBody = JsonConvert.DeserializeObject<PetReqResponse>(_response.Content);
               // Validate that the response contains the expected pet name
               Assert.AreEqual(IDNewPet, responseBody.Id);
            //}
        }

        [When(@"I send a GET request to method ""([^""]*)"" and parm ""([^""]*)""")]
        public async Task WhenISendAGETRequestToMethodAndParm(string findByStatus, string parm)
        {
            switch (findByStatus)
            {
                case "findByStatus":
                    if (parm == "available" || parm == "pending" || parm == "sold")
                    {
                        // Convert string to FindeByStatus enum
                        if (Enum.TryParse<FindeByStatus>(parm, true, out var statusEnum))
                        {
                            _response = await api.GetFindeByStatusPet(statusEnum);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid status value: {parm}");
                        }
                    }
                    break;
                  case "findByTags":
                    _response = await api.GetFindeByTagsPet(parm);
                   break;
                  case "findByID":
                    int id;
                    if (int.TryParse(parm, out id))
                    {
                        _response = await api.GetFindeByIDPet(id);
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid ID value: {parm}");
                    }
                  break;
            }
        }


        [Then(@"the response body should contain a list of pets with status ""([^""]*)""")]
        public async Task ThenTheResponseBodyShouldContainAListOfPetsWithStatusAsync(string parm)
        {
            // Deserialize JSON
            string json = _response.Content;
            var pets = JsonConvert.DeserializeObject<List<MODELS.RequestAndResponse.Pet.PetReqResponse>>(json);

            // 
            Assert.IsTrue(pets.All(p => p.Status == parm), "Not all pets are available!");
        }

        [Then(@"the response body should contain a list of pets with the tag ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainAListOfPetsWithTheTag(string parm)
        {
            string json = _response.Content;

            // Try deserializing as a list first
            List<MODELS.RequestAndResponse.Pet.PetReqResponse> pets;

            if (json.TrimStart().StartsWith("["))
            {
                pets = JsonConvert.DeserializeObject<List<MODELS.RequestAndResponse.Pet.PetReqResponse>>(json);
            }
            else
            {
                // If JSON is a single object, wrap it into a list
                var singlePet = JsonConvert.DeserializeObject<MODELS.RequestAndResponse.Pet.PetReqResponse>(json);
                pets = new List<MODELS.RequestAndResponse.Pet.PetReqResponse> { singlePet };
            }
            // 
            Assert.IsTrue(pets.All(p => p.Tags.First().Name == parm), $"Not all pets have parm: {parm}!");
        }

        [Then(@"the pet name should not be empty")]
        public void ThenThePetNameShouldNotBeEmpty()
        {
            string json = _response.Content;

            // Try deserializing as a list first
            List<MODELS.RequestAndResponse.Pet.PetReqResponse> pets;

            if (json.TrimStart().StartsWith("["))
            {
                pets = JsonConvert.DeserializeObject<List<MODELS.RequestAndResponse.Pet.PetReqResponse>>(json);
            }
            else
            {
                // If JSON is a single object, wrap it into a list
                var singlePet = JsonConvert.DeserializeObject<MODELS.RequestAndResponse.Pet.PetReqResponse>(json);
                pets = new List<MODELS.RequestAndResponse.Pet.PetReqResponse> { singlePet };
            }
            // Assert all pet names are not null or empty
            Assert.IsTrue(pets.All(p => !string.IsNullOrEmpty(p.Name)), "Some pets have empty names!");
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
        }
    }
}
