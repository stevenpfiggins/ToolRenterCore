using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.Contexts;
using ToolRenterCore.Database.DataContract.Request.Interfaces;
using ToolRenterCore.Database.DataContract.Request.RAOs;
using ToolRenterCore.Database.Entities.Request;

namespace ToolRenterCore.Database.Request
{
    public class RequestRepository : IRequestRepository
    {
        private readonly IMapper _mapper;
        private readonly ToolRenterContext _context;

        public RequestRepository(IMapper mapper, ToolRenterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateRequest(RequestCreateRAO rao)
        {
            var entity = _mapper.Map<RequestEntity>(rao);

            await _context.RequestTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteRequest(int id)
        {
            var query = await _context.RequestTableAccess.SingleAsync(q => q.RequestEntityId == id);
            _context.RequestTableAccess.Remove(query);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<RequestGetListItemRAO>> GetRequest()
        {
            var query = await _context.RequestTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<RequestGetListItemRAO>>(query);

            return rao;
        }

        public async Task<RequestGetListItemRAO> GetRequestById(int id)
        {
            var query = await _context.RequestTableAccess.SingleAsync(q => q.RequestEntityId == id);
            var rao = _mapper.Map<RequestGetListItemRAO>(query);

            return rao;
        }

        public async Task<bool> UpdateRequest(RequestUpdateRAO rao)
        {
            var entity = await _context.RequestTableAccess.SingleOrDefaultAsync(e => e.RequestEntityId == rao.RequestEntityId);
            entity.BeginningDateRequestedUtc = rao.BeginningDateRequestedUtc;
            entity.EndingDateRequestedUtc = rao.EndingDateRequestedUtc;
            entity.EquipmentEntityId = rao.EquipmentEntityId;
            entity.ModifiedUtc = rao.ModifiedUtc;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
