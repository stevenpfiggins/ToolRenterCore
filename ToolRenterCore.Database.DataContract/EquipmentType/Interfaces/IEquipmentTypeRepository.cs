﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.DataContract.EquipmentType.RAOs;

namespace ToolRenterCore.Database.DataContract.EquipmentType.Interfaces
{
    public interface IEquipmentTypeRepository
    {
        Task<bool> CreateEquipmentType(EquipmentTypeCreateRAO rao);
        Task<IEnumerable<EquipmentTypeListItemRAO>> GetEquipmentType();

    }
}
