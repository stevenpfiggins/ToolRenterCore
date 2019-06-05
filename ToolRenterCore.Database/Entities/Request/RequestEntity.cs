using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenterCore.Database.Entities.Request
{
    public class RequestEntity
    {
        [Key]
        public int RequestEntityId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int EquipmentEntityId { get; set; }

        [Required]
        public DateTimeOffset BeginningDateRequestedUtc { get; set; }

        [Required]
        public DateTimeOffset EndingDateRequestedUtc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? UpdatedUtc { get; set; }
    }
}
