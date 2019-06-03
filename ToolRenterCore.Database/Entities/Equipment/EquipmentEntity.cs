using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenterCore.Database.Entities.Equipment
{
    public class EquipmentEntity
    {
        [Key]
        public int EquipmentEntityId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int EquipmentTypeEntityId { get; set; }

        [Required]
        public string EquipmentName { get; set; }

        [Required]
        public string EquipmentDescription { get; set; }

        [Required]
        public decimal EquipmentRate { get; set; }

        [Required]
        public string PhotoLink { get; set; }

        public DateTimeOffset? CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
