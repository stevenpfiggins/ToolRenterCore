using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.DataContract.Auth.RAOs;

namespace ToolRenterCore.Database.DataContract.User
{
    public interface IUserRepository
    {
        Task<ReceivedExistingUserRAO> GetUser(int userId);
    }
}
