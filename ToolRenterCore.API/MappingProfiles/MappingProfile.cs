using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRenterCore.API.DataContract.Auth;
using ToolRenterCore.API.DataContract.Equipment;
using ToolRenterCore.Business.DataContract.Auth.DTOs;
using ToolRenterCore.Business.DataContract.Equipment;
using ToolRenterCore.Database.DataContract.Auth.RAOs;
using ToolRenterCore.Database.DataContract.Equipment;
using ToolRenterCore.Database.Entities.People;

namespace ToolRenterCore.API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Registration Oriented
            CreateMap<RegisterUserRequest, RegisterUserDTO>();
            CreateMap<RegisterUserDTO, RegisterUserRAO>();
            CreateMap<RegisterUserRAO, UserEntity>();
            CreateMap<LoginUserRequest, QueryForExistingUserDTO>();

            // Login Oriented
            CreateMap<QueryForExistingUserDTO, QueryForExistingUserRAO>();
            CreateMap<QueryForExistingUserRAO, UserEntity>();
            CreateMap<UserEntity, ReceivedExistingUserRAO>();
            CreateMap<ReceivedExistingUserRAO, ReceivedExistingUserDTO>();
            CreateMap<ReceivedExistingUserDTO, ReceivedExistingUserResponse>();
            CreateMap<LoginUserRequest, ReceivedExistingUserResponse>();

            // Authorization Check Oriented
            CreateMap<RegisterUserRAO, QueryForExistingUserRAO>();
        }
    }
}
