using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToolRenterCore.Database.DataContract.Equipment
{
    public interface IEquipmentRepository
    {
        Task<bool> CreateEquipment(EquipmentCreateRAO rao);

    }
}
