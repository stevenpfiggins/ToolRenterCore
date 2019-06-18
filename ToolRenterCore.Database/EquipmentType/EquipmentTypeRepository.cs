using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.Contexts;
using ToolRenterCore.Database.DataContract.EquipmentType;
using ToolRenterCore.Database.DataContract.EquipmentType.Interfaces;
using ToolRenterCore.Database.DataContract.EquipmentType.RAOs;
using ToolRenterCore.Database.Entities.EquipmentType;

namespace ToolRenterCore.Database.EquipmentType
{
    public class EquipmentTypeRepository : IEquipmentTypeRepository
    {
        private readonly IMapper _mapper;
        private readonly ToolRenterContext _context;

        public EquipmentTypeRepository(IMapper mapper, ToolRenterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateEquipmentType(EquipmentTypeCreateRAO rao)
        {
            var entity = _mapper.Map<EquipmentTypeEntity>(rao);

            await _context.EquipmentTypeTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<EquipmentTypeListItemRAO>> GetEquipmentType()
        {
            var query = await _context.EquipmentTypeTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<EquipmentTypeListItemRAO>>(query);

            return rao;
        }

        public async Task<EquipmentTypeListItemRAO> GetEquipmentTypeById(int id)
        {
            var query = await _context.EquipmentTypeTableAccess.SingleAsync(q => q.EquipmentTypeEntityId == id);
            var rao = _mapper.Map<EquipmentTypeListItemRAO>(query);

            return rao;
        }

        public async Task<bool> UpdateEquipmentType(EquipmentTypeUpdateRAO rao)
        {
            var entity = await _context.EquipmentTypeTableAccess.SingleOrDefaultAsync(e => e.EquipmentTypeEntityId == rao.EquipmentTypeEntityId);
            entity.EquipmentTypeEntityId = rao.EquipmentTypeEntityId;
            entity.EquipmentTypeString = rao.EquipmentTypeString;

            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteEquipmentType(int id)
        {
            var query = await _context.EquipmentTypeTableAccess.SingleAsync(q => q.EquipmentTypeEntityId == id);
            _context.EquipmentTypeTableAccess.Remove(query);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
