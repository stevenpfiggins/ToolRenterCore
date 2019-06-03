using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRenterCore.API.DataContract.Equipment;
using ToolRenterCore.Business.DataContract.Equipment;
using ToolRenterCore.Database.DataContract.Equipment;
using ToolRenterCore.Database.Entities.Equipment;

namespace ToolRenterCore.API.MappingProfiles
{
    public class EquipmentMappingProfile : Profile
    {
        public EquipmentMappingProfile()
        {
            //Equipment Create Mapping
            CreateMap<EquipmentCreateRequest, EquipmentCreateDTO>();
            CreateMap<EquipmentCreateDTO, EquipmentCreateRAO>();
            CreateMap<EquipmentCreateRAO, EquipmentEntity>();
        }
    }
}
