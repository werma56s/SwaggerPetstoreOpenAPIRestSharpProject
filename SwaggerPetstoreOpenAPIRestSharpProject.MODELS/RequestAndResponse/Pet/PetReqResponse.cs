using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetstoreOpenAPIRestSharpProject.MODELS.RequestAndResponse.Pet
{
    public class PetReqResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string[] PhotoUrls { get; set; }
        public Tag[] Tags { get; set; }
        public string Status { get; set; }
    }

    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}
