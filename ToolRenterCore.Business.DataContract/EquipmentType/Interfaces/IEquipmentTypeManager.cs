using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.EquipmentType.DTOs;

namespace ToolRenterCore.Business.DataContract.EquipmentType.Interfaces
{
    public interface IEquipmentTypeManager
    {
        Task<bool> CreateEquipmentType(EquipmentTypeCreateDTO dto);
        Task<IEnumerable<EquipmentTypeListItemDTO>> GetEquipmentType();

    }
}
