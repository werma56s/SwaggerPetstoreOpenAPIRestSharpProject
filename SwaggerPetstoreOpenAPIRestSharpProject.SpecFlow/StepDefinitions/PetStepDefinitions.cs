using System;
using TechTalk.SpecFlow;

namespace SwaggerPetstoreOpenAPIRestSharpProject.SpecFlow.StepDefinitions
{
    [Binding]
    public class PetStepDefinitions
    {
        [Given(@"I am an authorized user")]
        public void GivenIAmAnAuthorizedUser()
        {
            throw new PendingStepException();
        }

        [When(@"I send a POST request to ""([^""]*)"" with the following data:")]
        public void WhenISendAPOSTRequestToWithTheFollowingData(string p0, Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the response body should contain the name ""([^""]*)""")]
        public void ThenTheResponseBodyShouldContainTheName(string dog)
        {
            throw new PendingStepException();
        }

        [Then(@"the pet status should be ""([^""]*)""")]
        public void ThenThePetStatusShouldBe(string available)
        {
            throw new PendingStepException();
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
