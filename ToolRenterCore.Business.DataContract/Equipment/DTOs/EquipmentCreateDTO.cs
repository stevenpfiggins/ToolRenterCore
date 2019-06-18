using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.Equipment
{
    public class EquipmentCreateDTO
    {
        public int OwnerId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public int EquipmentTypeEntityId { get; set; }
        public decimal EquipmentRate { get; set; }
        public IFormFile PhotoUpload { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
