using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.DataContract.Auth.RAOs;

namespace ToolRenterCore.Database.DataContract.Auth.Interfaces
{
    public interface IAuthRepository
    {
        Task<ReceivedExistingUserRAO> Register(RegisterUserRAO regUserRAO, string password);
        Task<ReceivedExistingUserRAO> Login(QueryForExistingUserRAO queryRao);
        Task<bool> UserExists(string username);
        Task<ReceivedExistingUserRAO> GetUserById(int ownerId);
    }
}
