using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.ViewResult;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Service
{
    public class ImageService: IImageService
    {

        public async Task<String> UploadIamge(string ImagePath,IFormFile imageData)
        {

            try { 
            string uploadFolder = ImagePath;

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageData.FileName;
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageData.CopyToAsync(fileStream);
            }
            ImagePath = "/Images/" + uniqueFileName;


           return "Image Added";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
