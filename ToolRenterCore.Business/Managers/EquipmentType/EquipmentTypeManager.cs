using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.EquipmentType.DTOs;
using ToolRenterCore.Business.DataContract.EquipmentType.Interfaces;
using ToolRenterCore.Database.DataContract.EquipmentType.RAOs;
using ToolRenterCore.Database.DataContract.EquipmentType.Interfaces;

namespace ToolRenterCore.Business.Managers.EquipmentType
{
    public class EquipmentTypeManager : IEquipmentTypeManager
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentTypeRepository _repository;

        public EquipmentTypeManager(IMapper mapper, IEquipmentTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateEquipmentType(EquipmentTypeCreateDTO dto)
        {
            var rao = _mapper.Map<EquipmentTypeCreateRAO>(dto);
            if (await _repository.CreateEquipmentType(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EquipmentTypeListItemDTO>> GetEquipmentType()
        {
            var rao = await _repository.GetEquipmentType();
            var dto = _mapper.Map<IEnumerable<EquipmentTypeListItemDTO>>(rao);

            return dto;
        }
    }
}
