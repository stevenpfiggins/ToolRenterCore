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

        public async Task<IEnumerable<EquipmentGetListItemDTO>> GetEquipment()
        {
            var rao = await _repository.GetEquipment();
            var dto = _mapper.Map<IEnumerable<EquipmentGetListItemDTO>>(rao);

            return dto;
        }

        public async Task<EquipmentGetListItemDTO> GetEquipmentById(int id)
        {
            var rao = await _repository.GetEquipmentById(id);
            var dto = _mapper.Map<EquipmentGetListItemDTO>(rao);

            return dto;
        }

        public async Task<bool> UpdateEquipment(EquipmentUpdateDTO dto)
        {
            var rao = _mapper.Map<EquipmentUpdateRAO>(dto);
            var engine = new SaveFileEngine();
            var uri = engine.Upload(dto.PhotoUpload);
            rao.PhotoLink = uri;

            if (await _repository.UpdateEquipment(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEquipment(int id)
        {
            if (await _repository.DeleteEquipment(id))
                return true;
            throw new NotImplementedException();
        }
    }
}
