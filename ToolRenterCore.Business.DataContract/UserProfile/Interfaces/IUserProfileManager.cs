using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.UserProfile.DTOs;

namespace ToolRenterCore.Business.DataContract.UserProfile.Interfaces
{
    public interface IUserProfileManager
    {
        Task<bool> CreateUserProfile(UserProfileCreateDTO dto);
        Task<IEnumerable<UserProfileGetListItemDTO>> GetUserProfiles();
        Task<UserProfileGetListItemDTO> GetUserProfileById(int id);
        Task<bool> UpdateUserProfile(UserProfileUpdateDTO dto);
        Task<bool> DeleteUserProfile(int id);
    }
}
