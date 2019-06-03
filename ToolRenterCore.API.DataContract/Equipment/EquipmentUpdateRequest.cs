﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenterCore.API.DataContract.Equipment
{
    public class EquipmentUpdateRequest
    {
        public int EquipmentEntityId { get; set; }
        public int OwnerId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal EquipmentRate { get; set; }
    }
}