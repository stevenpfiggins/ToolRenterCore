using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.DataContract.Auth.RAOs;

namespace ToolRenterCore.Database.DataContract.Roles
{
    public interface IRoleRepository
    {
        Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role);
    }
}
