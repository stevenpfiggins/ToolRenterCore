using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.Contexts;
using ToolRenterCore.Database.DataContract.UserProfile.Interfaces;
using ToolRenterCore.Database.DataContract.UserProfile.RAOs;
using ToolRenterCore.Database.Entities.UserProfile;

namespace ToolRenterCore.Database.UserProfile
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IMapper _mapper;
        private readonly ToolRenterContext _context;

        public UserProfileRepository(IMapper mapper, ToolRenterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateUserProfile(UserProfileCreateRAO rao)
        {
            var entity = _mapper.Map<UserProfileEntity>(rao);

            await _context.UserProfileTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteUserProfile(int id)
        {
            var query = await _context.UserProfileTableAccess.SingleAsync(q => q.UserProfileEntityId == id);
            _context.UserProfileTableAccess.Remove(query);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<UserProfileGetListItemRAO>> GetUserProfiles()
        {
            var query = await _context.UserProfileTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<UserProfileGetListItemRAO>>(query);

            return rao;
        }

        public async Task<UserProfileGetListItemRAO> GetUserProfileById(int id)
        {
            var query = await _context.UserProfileTableAccess.SingleAsync(q => q.UserProfileEntityId == id);
            var rao = _mapper.Map<UserProfileGetListItemRAO>(query);

            return rao;
        }

        public async Task<bool> UpdateUserProfile(UserProfileUpdateRAO rao)
        {
            var entity = await _context.UserProfileTableAccess.SingleOrDefaultAsync(e => e.UserProfileEntityId == rao.UserProfileEntityId);
            entity.ProfilePicture = rao.ProfilePicture;
            entity.ZipCode = rao.ZipCode;
            entity.ModifiedUtc = rao.ModifiedUtc;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
