using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.Request.DTOs;
using ToolRenterCore.Business.DataContract.Request.Interfaces;
using ToolRenterCore.Database.DataContract.Request.Interfaces;
using ToolRenterCore.Database.DataContract.Request.RAOs;

namespace ToolRenterCore.Business.Managers.Request
{
    public class RequestManager : IRequestManager
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _repository;

        public RequestManager(IMapper mapper, IRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateRequest(RequestCreateDTO dto)
        {
            var rao = Mapper.Map<RequestCreateRAO>(dto);

            if (await _repository.CreateRequest(rao))
                return true;

            throw new Exception("Item could not be created.");
        }

        public async Task<bool> DeleteRequest(int id)
        {
            if (await _repository.DeleteRequest(id))
                return true;

            throw new Exception("Item could not be deleted.");
        }

        public async Task<IEnumerable<RequestGetListItemDTO>> GetRequest()
        {
            var rao = await _repository.GetRequest();
            var dto = _mapper.Map<IEnumerable<RequestGetListItemDTO>>(rao);

            return dto;
        }

        public async Task<RequestGetListItemDTO> GetRequestById(int id)
        {
            var rao = await _repository.GetRequestById(id);
            var dto = _mapper.Map<RequestGetListItemDTO>(rao);

            return dto;
        }

        public async Task<bool> UpdateRequest(RequestUpdateDTO dto)
        {
            var rao = _mapper.Map<RequestUpdateRAO>(dto);

            if (await _repository.UpdateRequest(rao))
                return true;

            throw new Exception("Item could not be updated.");
        }
    }
}
