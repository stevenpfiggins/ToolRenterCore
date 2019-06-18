using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Business.DataContract.UserProfile.DTOs;
using ToolRenterCore.Business.DataContract.UserProfile.Interfaces;
using ToolRenterCore.Business.Engine.Equipment;
using ToolRenterCore.Database.DataContract.UserProfile.Interfaces;
using ToolRenterCore.Database.DataContract.UserProfile.RAOs;

namespace ToolRenterCore.Business.Managers.UserProfile
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _repository;

        public UserProfileManager(IMapper mapper, IUserProfileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateUserProfile(UserProfileCreateDTO dto)
        {
            var rao = _mapper.Map<UserProfileCreateRAO>(dto);
            var engine = new SaveFileEngine();
            var uri = engine.Upload(dto.PhotoUpload);
            rao.ProfilePicture = uri;

            if (await _repository.CreateUserProfile(rao))
                return true;

            throw new Exception("User Profile could not be created.");
        }

        public async Task<bool> DeleteUserProfile(int id)
        {
            if (await _repository.DeleteUserProfile(id))
                return true;

            throw new Exception("User Profile could not be deleted.");
        }

        public async Task<IEnumerable<UserProfileGetListItemDTO>> GetUserProfiles()
        {
            var rao = await _repository.GetUserProfiles();
            var dto = _mapper.Map<IEnumerable<UserProfileGetListItemDTO>>(rao);

            return dto;
        }

        public async Task<UserProfileGetListItemDTO> GetUserProfileById(int id)
        {
            var rao = await _repository.GetUserProfileById(id);
            var dto = _mapper.Map<UserProfileGetListItemDTO>(rao);

            return dto;
        }

        public async Task<bool> UpdateUserProfile(UserProfileUpdateDTO dto)
        {
            var rao = _mapper.Map<UserProfileUpdateRAO>(dto);
            var engine = new SaveFileEngine();
            var uri = engine.Upload(dto.PhotoUpload);
            rao.ProfilePicture = uri;

            if (await _repository.UpdateUserProfile(rao))
                return true;

            throw new Exception("User Profile could not be updated.");
        }
    }
}
