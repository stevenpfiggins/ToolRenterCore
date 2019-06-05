using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.Business.DataContract.Equipment
{
    public class EquipmentGetListItemDTO
    {
        public int EquipmentEntityId { get; set; }
        public int OwnerId { get; set; }
        public int EquipmentTypeEntityId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal EquipmentRate { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public string PhotoLink { get; set; }
    }
}
