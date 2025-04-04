using RestSharp;
using SwaggerPetstoreOpenAPIRestSharpProject.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.API
{
    internal class APIClientStore : IAPIClientStore, IDisposable
    {
        public Task<RestResponse> DeleteOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> GetInventoryByStatus()
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> PlaceOrderForPet<T>(T payload) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
