using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.Engine.Equipment
{
    public class SaveFileEngine
    {
        public string Upload(IFormFile file)
        {
            Account account = new Account(
                "dm7lepkwv",
                "453935962484596",
                "h68wAGIHesHWZKhQB5huALUPdW0");

            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("test", file.OpenReadStream()),
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            return uploadResult.Uri.ToString();
        }
    }
}
