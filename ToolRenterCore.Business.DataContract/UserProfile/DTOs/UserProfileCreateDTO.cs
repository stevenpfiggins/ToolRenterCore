using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.UserProfile.DTOs
{
    public class UserProfileCreateDTO
    {
        public int OwnerId { get; set; }
        public string ZipCode { get; set; }
        public IFormFile PhotoUpload { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
