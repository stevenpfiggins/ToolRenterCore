using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.UserProfile
{
    public class UserProfileCreateRequest
    {
        public string ZipCode { get; set; }
        public IFormFile PhotoUpload { get; set; }
    }
}
