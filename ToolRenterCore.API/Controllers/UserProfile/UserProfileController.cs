using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRenterCore.API.DataContract.UserProfile;
using ToolRenterCore.Business.DataContract.UserProfile.DTOs;
using ToolRenterCore.Business.DataContract.UserProfile.Interfaces;

namespace ToolRenterCore.API.Controllers.UserProfile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileManager _manager;

        public UserProfileController(IMapper mapper, IUserProfileManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserProfile([FromForm]UserProfileCreateRequest request)
        {
            var dto = _mapper.Map<UserProfileCreateDTO>(request);
            dto.OwnerId = GetUser();
            dto.CreatedUtc = DateTime.Now;

            if (await _manager.CreateUserProfile(dto))
                return StatusCode(201);

            throw new Exception("User Profile could not be created.");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfiles()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetUserProfiles();
            var response = _mapper.Map<IEnumerable<UserProfileGetListItemResponse>>(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetUserProfileById(id);
            var response = _mapper.Map<UserProfileGetListItemResponse>(dto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromForm]UserProfileUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<UserProfileUpdateDTO>(request);
            dto.ModifiedUtc = DateTime.Now;

            if (await _manager.UpdateUserProfile(dto))
                return StatusCode(202);

            throw new Exception("User Profile could not be updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteUserProfile(id))
                return StatusCode(207);

            throw new Exception("User Profile could not be deleted.");
        }

        private int GetUser()
        {
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return identityClaimNum;
        }
    }
}