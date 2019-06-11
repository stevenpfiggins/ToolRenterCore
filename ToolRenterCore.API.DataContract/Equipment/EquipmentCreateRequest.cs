using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.Equipment
{
    public class EquipmentCreateRequest
    {
        public string EquipmentName { get; set; }
        public int EquipmentTypeEntityId { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal EquipmentRate { get; set; }
        public IFormFile PhotoUpload { get; set; }
    }
}
