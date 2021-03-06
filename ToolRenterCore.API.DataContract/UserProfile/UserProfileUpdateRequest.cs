﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.UserProfile
{
    public class UserProfileUpdateRequest
    {
        public int UserProfileEntityId { get; set; }
        public int OwnerId { get; set; }
        public string ZipCode { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
