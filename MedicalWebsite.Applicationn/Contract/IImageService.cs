using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Contract
{
    public interface IImageService
    {
        Task<String> UploadIamge(string ImagePath, IFormFile imageData);
    }
}
