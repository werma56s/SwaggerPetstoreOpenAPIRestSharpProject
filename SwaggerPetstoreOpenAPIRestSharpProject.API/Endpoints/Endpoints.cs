using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetstoreOpenAPIRestSharpProject.API.Endpoints
{
    public class Endpoints
    {
        public static readonly string BaseUrl = "https://petstore3.swagger.io/api/v3";
        public static readonly string User = "/user";
        public static readonly string UserLogin = "/user/login";
        public static readonly string UserLogout = "/user/logout";
        public static readonly string UserCreate = "/user/createWithList";
        public static readonly string UserUpdate = "/user/{username}";
        public static readonly string UserDelete = "/user/{username}";
        public static readonly string UserPut = "/user/{username}";
        public static readonly string Pet = "/pet";
        public static readonly string PetFindByStatus = "/pet/findByStatus";
        public static readonly string PetFindByTags = "/pet/findByTags";
        public static readonly string PetFindById = "/pet/{id}";
        public static readonly string PetUpdate = "/pet/{id}";
        public static readonly string PetUploadImage = "/pet/{petId}/uploadImage";
        public static readonly string Store = "/store";
        public static readonly string StoreOrder = "/store/order";
        public static readonly string StoreInventory = "/store/inventory";
        public static readonly string StoreDeleteOrder = "/store/order/{orderId}";
        public static readonly string StoreGetOrder = "/store/order/{orderId}";

    }
}
