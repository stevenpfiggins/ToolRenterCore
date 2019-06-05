using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.EquipmentType
{
    public class EquipmentTypeUpdateRequest
    {
        public int EquipmentTypeEntityId { get; set; }
        public string EquipmentTypeString { get; set; }
    }
}
