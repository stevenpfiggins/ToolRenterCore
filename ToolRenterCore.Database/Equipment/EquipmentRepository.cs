using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<EquipmentGetListItemRAO>> GetEquipment()
        {
            var query = await _context.EquipmentTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<EquipmentGetListItemRAO>>(query);

            return rao;
        }

        public async Task<EquipmentGetListItemRAO> GetEquipmentById(int id)
        {
            var query = await _context.EquipmentTableAccess.SingleAsync(q => q.EquipmentEntityId == id);
            var rao = _mapper.Map<EquipmentGetListItemRAO>(query);

            return rao;
        }

        public async Task<bool> UpdateEquipment(EquipmentUpdateRAO rao)
        {
            var entity = await _context.EquipmentTableAccess.SingleOrDefaultAsync(e => e.EquipmentEntityId == rao.EquipmentEntityId);
            entity.PhotoLink = rao.PhotoLink;
            entity.EquipmentName = rao.EquipmentName;
            entity.EquipmentTypeEntityId = rao.EquipmentTypeEntityId;
            entity.EquipmentDescription = rao.EquipmentDescription;
            entity.EquipmentRate = rao.EquipmentRate;
            entity.ModifiedUtc = rao.ModifiedUtc;

            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteEquipment(int id)
        {
            var query = await _context.EquipmentTableAccess.SingleAsync(q => q.EquipmentEntityId == id);
            _context.EquipmentTableAccess.Remove(query);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
