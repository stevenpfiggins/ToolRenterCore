using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRenterCore.API.DataContract.UserProfile;
using ToolRenterCore.Business.DataContract.UserProfile.DTOs;
using ToolRenterCore.Database.DataContract.UserProfile.RAOs;
using ToolRenterCore.Database.Entities.UserProfile;

namespace ToolRenterCore.API.MappingProfiles
{
    public class UserProfileMappingProfile : Profile
    {
        public UserProfileMappingProfile()
        {

            // Request Create Mapping
            CreateMap<UserProfileCreateRequest, UserProfileCreateDTO>();
            CreateMap<UserProfileCreateDTO, UserProfileCreateRAO>();
            CreateMap<UserProfileCreateRAO, UserProfileEntity>();

            // Request Get Mapping
            CreateMap<UserProfileEntity, UserProfileGetListItemRAO>();
            CreateMap<UserProfileGetListItemRAO, UserProfileGetListItemDTO>();
            CreateMap<UserProfileGetListItemDTO, UserProfileGetListItemResponse>();

            // Request Update Mapping
            CreateMap<UserProfileUpdateRequest, UserProfileUpdateDTO>();
            CreateMap<UserProfileUpdateDTO, UserProfileUpdateRAO>();
            CreateMap<UserProfileUpdateRAO, UserProfileEntity>();
        }
    }
}
