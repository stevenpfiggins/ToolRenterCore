using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.Auth.DTOs;

namespace ToolRenterCore.Business.DataContract.Auth.Interfaces
{
    public interface IAuthManager
    {
        Task<ReceivedExistingUserDTO> RegisterUser(RegisterUserDTO userDTO);
        Task<ReceivedExistingUserDTO> LoginUser(QueryForExistingUserDTO userDTO);
        Task<bool> UserExists(string user);
    }
}
