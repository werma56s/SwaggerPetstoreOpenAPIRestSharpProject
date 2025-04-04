using RestSharp;
using SwaggerPetstoreOpenAPIRestSharpProject.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.API
{
    internal class APIClientUser : IAPIClientUser, IDisposable
    {
        public Task<RestResponse> CreateUser<T>(T payload) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> CreateUsersWithList<T>(T payload) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> LogoutUser()
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> UpdateUser<T>(T payload) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
