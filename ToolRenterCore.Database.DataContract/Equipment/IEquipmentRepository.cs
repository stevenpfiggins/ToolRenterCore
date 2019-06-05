using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToolRenterCore.Database.DataContract.Equipment
{
    public interface IEquipmentRepository
    {
        Task<bool> CreateEquipment(EquipmentCreateRAO rao);
        Task<IEnumerable<EquipmentGetListItemRAO>> GetEquipment();
        Task<EquipmentGetListItemRAO> GetEquipmentById(int id);
        Task<bool> UpdateEquipment(EquipmentUpdateRAO rao);
        Task<bool> DeleteEquipment(int id);
    }
}
