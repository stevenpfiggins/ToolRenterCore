using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRenterCore.API.DataContract.Request;
using ToolRenterCore.Business.DataContract.Request.DTOs;
using ToolRenterCore.Database.DataContract.Request.RAOs;
using ToolRenterCore.Database.Entities.Request;

namespace ToolRenterCore.API.MappingProfiles
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {

            // Request Create Mapping
            CreateMap<RequestCreateRequest, RequestCreateDTO>();
            CreateMap<RequestCreateDTO, RequestCreateRAO>();
            CreateMap<RequestCreateRAO, RequestEntity>();

            // Request Get Mapping
            CreateMap<RequestEntity, RequestGetListItemRAO>();
            CreateMap<RequestGetListItemDTO, RequestGetListItemResponse>();
            CreateMap<RequestGetListItemRAO, RequestGetListItemDTO>();

            // Request Update Mapping
            CreateMap<RequestUpdateRequest, RequestUpdateDTO>();
            CreateMap<RequestUpdateDTO, RequestUpdateRAO>();
            CreateMap<RequestUpdateRAO, RequestEntity>();
        }
    }
}
