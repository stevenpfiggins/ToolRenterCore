using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.Contexts;
using ToolRenterCore.Database.DataContract.Equipment;
using ToolRenterCore.Database.Entities.Equipment;

namespace ToolRenterCore.Database.Equipment
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly IMapper _mapper;
        private readonly ToolRenterContext _context;

        public EquipmentRepository(IMapper mapper, ToolRenterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateEquipment(EquipmentCreateRAO rao)
        {
            var entity = _mapper.Map<EquipmentEntity>(rao);

            await _context.EquipmentTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
