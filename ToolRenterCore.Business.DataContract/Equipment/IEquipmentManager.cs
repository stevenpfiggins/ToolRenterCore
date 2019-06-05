using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToolRenterCore.Business.DataContract.Equipment
{
    public interface IEquipmentManager
    {
        Task<bool> CreateEquipment(EquipmentCreateDTO dto);
        Task<IEnumerable<EquipmentGetListItemDTO>> GetEquipment();
        Task<EquipmentGetListItemDTO> GetEquipmentById(int id);
        Task<bool> UpdateEquipment(EquipmentUpdateDTO dto);
        Task<bool> DeleteEquipment(int id);
    }
}