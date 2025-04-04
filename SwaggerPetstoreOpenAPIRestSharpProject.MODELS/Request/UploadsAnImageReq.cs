using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetstoreOpenAPIRestSharpProject.MODELS.Request
{
    public class UploadsAnImageReq
    {
        public int PetId { get; set; } // Pet ID for which the image is being uploaded
        public string AdditionalMetadata { get; set; } // Any extra metadata related to the image
        public string FilePath { get; set; } // Path to the image file on disk (e.g., "C:/images/pet.jpg")
    }
}
