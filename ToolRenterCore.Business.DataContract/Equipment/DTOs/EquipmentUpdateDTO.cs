using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.Equipment
{
    public class EquipmentUpdateDTO
    {
        public int EquipmentEntityId { get; set; }
        public int EquipmentTypeEntityId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal EquipmentRate { get; set; }
        public IFormFile PhotoUpload { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
