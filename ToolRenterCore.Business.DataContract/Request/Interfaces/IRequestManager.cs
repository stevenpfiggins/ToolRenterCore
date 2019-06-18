using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.Request.DTOs;

namespace ToolRenterCore.Business.DataContract.Request.Interfaces
{
    public interface IRequestManager
    {
        Task<bool> CreateRequest(RequestCreateDTO dto);
        Task<IEnumerable<RequestGetListItemDTO>> GetRequest();
        Task<RequestGetListItemDTO> GetRequestById(int id);
        Task<bool> UpdateRequest(RequestUpdateDTO dto);
        Task<bool> DeleteRequest(int id);
    }
}
