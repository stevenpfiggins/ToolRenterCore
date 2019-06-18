using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.DataContract.UserProfile.RAOs;

namespace ToolRenterCore.Database.DataContract.UserProfile.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<bool> CreateUserProfile(UserProfileCreateRAO rao);
        Task<IEnumerable<UserProfileGetListItemRAO>> GetUserProfiles();
        Task<UserProfileGetListItemRAO> GetUserProfileById(int id);
        Task<bool> UpdateUserProfile(UserProfileUpdateRAO rao);
        Task<bool> DeleteUserProfile(int id);
    }
}
