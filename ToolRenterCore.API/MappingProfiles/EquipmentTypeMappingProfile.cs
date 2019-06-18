using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRenterCore.API.DataContract.EquipmentType;
using ToolRenterCore.Business.DataContract.EquipmentType.DTOs;
using ToolRenterCore.Database.DataContract.EquipmentType.RAOs;
using ToolRenterCore.Database.Entities.EquipmentType;

namespace ToolRenterCore.API.MappingProfiles
{
    public class EquipmentTypeMappingProfile : Profile
    {
        public EquipmentTypeMappingProfile()
        {
            //Equipment Type Create Mapping
            CreateMap<EquipmentTypeCreateRequest, EquipmentTypeCreateDTO>();
            CreateMap<EquipmentTypeCreateDTO, EquipmentTypeCreateRAO>();
            CreateMap<EquipmentTypeCreateRAO, EquipmentTypeEntity>();

            //Equipment Type Get Mapping
            CreateMap<EquipmentTypeEntity, EquipmentTypeListItemRAO>();
            CreateMap<EquipmentTypeListItemRAO, EquipmentTypeListItemDTO>();
            CreateMap<EquipmentTypeListItemDTO, EquipmentTypeListItemResponse>();
        }
    }
}
