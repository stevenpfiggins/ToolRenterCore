using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.DataContract.Request.RAOs;

namespace ToolRenterCore.Database.DataContract.Request.Interfaces
{
    public interface IRequestRepository
    {
        Task<bool> CreateRequest(RequestCreateRAO rao);
        Task<IEnumerable<RequestGetListItemRAO>> GetRequest();
        Task<RequestGetListItemRAO> GetRequestById(int id);
        Task<bool> UpdateRequest(RequestUpdateRAO rao);
        Task<bool> DeleteRequest(int id);
    }
}
