using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.Equipment
{
    public class EquipmentCreateRequest
    {
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal EquipmentRate { get; set; }
    }
}
