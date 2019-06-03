using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.Equipment;
using ToolRenterCore.Business.Engine;
using ToolRenterCore.Business.Engine.Equipment;
using ToolRenterCore.Database.DataContract.Equipment;

namespace ToolRenterCore.Business.Managers.Equipment
{
    public class EquipmentManager : IEquipmentManager
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentRepository _repository;

        public EquipmentManager( IMapper mapper, IEquipmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateEquipment(EquipmentCreateDTO dto)
        {
            var rao = _mapper.Map<EquipmentCreateRAO>(dto);
            var engine = new SaveFileEngine();
            var uri = engine.Upload(dto.PhotoUpload);
            rao.PhotoLink = uri;

            if (await _repository.CreateEquipment(rao))
                return true;

            throw new NotImplementedException();
        }
    }
}
