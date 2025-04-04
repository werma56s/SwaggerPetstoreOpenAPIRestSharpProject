using RestSharp;
using SwaggerPetstoreOpenAPIRestSharpProject.API.Interface;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.Enums;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.Request;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.API
{
    public class APIClientPet : IAPIClientPet, IDisposable
    {
        readonly RestClient _restClient;

        public APIClientPet(string baseUrl)
        {
            var option = new RestClientOptions(baseUrl);
            _restClient = new RestClient(option);
        }
        // Create a new pet in the store
        public async Task<RestResponse> CreatePet<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.Endpoints.Pet, Method.Post);
            request.AddJsonBody(payload);
            return await _restClient.ExecuteAsync(request);
        }

        // Delete a pet from the store by its ID
        public async Task<RestResponse> DeletePet(string api_key, int id)
        {
            var request = new RestRequest(Endpoints.Endpoints.Pet + $"/{id}", Method.Delete);
            request.AddHeader("api_key", api_key);
            return await _restClient.ExecuteAsync(request);
        }

        // Find a pet by its ID
        public async Task<RestResponse> GetFindeByIDPet(int id)
        {
            var request = new RestRequest(Endpoints.Endpoints.PetFindById.Replace("{id}", id.ToString()), Method.Get);
            return await _restClient.ExecuteAsync(request);
        }

        // Find pets by their status
        public async Task<RestResponse> GetFindeByStatusPet(FindeByStatus findeByStatus)
        {
            var request = new RestRequest(Endpoints.Endpoints.PetFindByStatus, Method.Get);
            request.AddQueryParameter("status", findeByStatus); // assuming 'findeByStatus' contains a Status property
            return await _restClient.ExecuteAsync(request);
        }

        // Find pets by tags
        public async Task<RestResponse> GetFindeByTagsPet(string findeByTags)
        {
            var request = new RestRequest(Endpoints.Endpoints.PetFindByTags, Method.Get);
            request.AddQueryParameter("tags", findeByTags);
            return await _restClient.ExecuteAsync(request);
        }

        // Upload an image for a pet
        public async Task<RestResponse> GetFindeByStatusPet(UploadsAnImageReq uploadsAnImage)
        {
            var request = new RestRequest(Endpoints.Endpoints.PetUploadImage, Method.Post);
            request.AddFile("file", uploadsAnImage.FilePath); // assuming UploadsAnImageReq contains a 'FilePath' property
            request.AddParameter("petId", uploadsAnImage.PetId); // assuming UploadsAnImageReq contains 'PetId'
            return await _restClient.ExecuteAsync(request);
        }

        // Update a pet in the store
        public async Task<RestResponse> UpdatePet<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.Endpoints.Pet, Method.Put);
            request.AddJsonBody(payload);
            return await _restClient.ExecuteAsync(request);
        }

        // Update a pet's data in the store by its ID
        public async Task<RestResponse> UpdateAPetInStore(int id, UpdatesAPetInStoreReq updatesAPetInStore)
        {
            var request = new RestRequest(Endpoints.Endpoints.PetUpdate.Replace("{id}", id.ToString()), Method.Post);
            request.AddJsonBody(updatesAPetInStore); // assuming UpdatesAPetInStoreReq contains the necessary data to update the pet
            return await _restClient.ExecuteAsync(request);
        }

        // Dispose of the RestClient if necessary
        public void Dispose()
        {
            // Dispose logic if needed (e.g., for RestClient)
        }
    }
}
