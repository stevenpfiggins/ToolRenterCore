using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.UserProfile.DTOs
{
    public class UserProfileGetListItemDTO
    {
        public int UserProfileEntityId { get; set; }
        public int OwnerId { get; set; }
        public string ZipCode { get; set; }
        public string ProfilePicture { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
