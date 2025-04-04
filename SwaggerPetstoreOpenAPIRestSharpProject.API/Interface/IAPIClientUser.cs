using RestSharp;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.Interface
{
    internal interface IAPIClientUser
    {
        // Create a new user
        Task<RestResponse> CreateUser<T>(T payload) where T : class;

        // Create a list of users
        Task<RestResponse> CreateUsersWithList<T>(T payload) where T : class;

        // Log in a user
        Task<RestResponse> LoginUser(string username, string password);

        // Log out the current logged-in user
        Task<RestResponse> LogoutUser();

        // Get user details by username
        Task<RestResponse> GetUserByUsername(string username);

        // Update user details by username
        Task<RestResponse> UpdateUser<T>(T payload) where T : class;

        // Delete user by username
        Task<RestResponse> DeleteUser(string username);
    }
}
