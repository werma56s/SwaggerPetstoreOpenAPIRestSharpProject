using RestSharp;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.Enums;
using SwaggerPetstoreOpenAPIRestSharpProject.MODELS.Request;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.Interface
{
    public interface IAPIClientPet
    {
        // Method to create a new pet in the store.
        // Accepts a generic object T representing the pet data (e.g., name, status, type, etc.)
        Task<RestResponse> CreatePet<T>(T payload) where T : class;

        // Method to update an existing pet in the store.
        // Accepts a generic object T containing the updated pet data.
        Task<RestResponse> UpdatePet<T>(T payload) where T : class;

        // Method to delete a pet from the store by its ID.
        // Requires an API key (api_key) and the pet's ID to be deleted.
        Task<RestResponse> DeletePet(string api_key, int id);

        // Method to find pets by their status in the store.
        // Accepts a FindeByStatus object that contains criteria for searching pets by status.
        Task<RestResponse> GetFindeByStatusPet(FindeByStatus findeByStatus);

        // Method to find pets by tags assigned to them in the store.
        // Accepts a string representing the tags (e.g., 'cute', 'friendly').
        Task<RestResponse> GetFindeByTagsPet(string findeByTags);

        // Method to get detailed information about a pet by its ID.
        // Accepts the pet's ID and returns the corresponding pet details.
        Task<RestResponse> GetFindeByIDPet(int id);

        // Method to update a pet in the store with form data (e.g., update its name or status).
        // Accepts the pet's ID and an object containing the updated data (UpdatesAPetInStoreReq).
        Task<RestResponse> UpdateAPetInStore(int id, UpdatesAPetInStoreReq updatesAPetInStore);

        // Method to upload an image for a pet.
        // Accepts an UploadsAnImageReq object containing the image data to upload.
        Task<RestResponse> GetFindeByStatusPet(UploadsAnImageReq uploadsAnImage);
    }
}
