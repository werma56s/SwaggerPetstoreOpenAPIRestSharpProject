using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.Interface
{
    internal interface IAPIClientStore
    {
        // Get inventory by status
        Task<RestResponse> GetInventoryByStatus();

        // Place an order for a pet
        Task<RestResponse> PlaceOrderForPet<T>(T payload) where T : class;

        // Get order by ID
        Task<RestResponse> GetOrderById(int orderId);

        // Delete an order by ID
        Task<RestResponse> DeleteOrderById(int orderId);
    }
}
