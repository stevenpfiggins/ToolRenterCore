using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenterCore.Database.Entities.UserProfile
{
    public class UserProfileEntity
    {
        [Required]
        public int UserProfileEntityId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        public DateTimeOffset? CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
