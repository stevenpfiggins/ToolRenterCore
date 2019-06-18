using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRenterCore.API.DataContract.EquipmentType;
using ToolRenterCore.Business.DataContract.EquipmentType.DTOs;
using ToolRenterCore.Business.DataContract.EquipmentType.Interfaces;

namespace ToolRenterCore.API.Controllers.EquipmentType
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class EquipmentTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentTypeManager _manager;

        public EquipmentTypeController(IMapper mapper, IEquipmentTypeManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        //Create Equipment Type
        [HttpPost]
        public async Task<IActionResult> PostEquipmentType(EquipmentTypeCreateRequest request)
        {
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var dto = _mapper.Map<EquipmentTypeCreateDTO>(request);

            if (await _manager.CreateEquipmentType(dto))
                return StatusCode(201);

            throw new Exception();
        }

        //GET All Equipment
        [HttpGet]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetEquipmentType()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetEquipmentType();
            var response = _mapper.Map<IEnumerable<EquipmentTypeListItemResponse>>(dto);

            return Ok(response); //Handle Exceptions
        }

        //GET EquipmentType Detail
        [HttpGet("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetEquipmentTypeById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetEquipmentTypeById(id);
            var response = _mapper.Map<EquipmentTypeListItemResponse>(dto);

            return Ok(response);
        }

        //PUT Equipment Type Update
        [HttpPut]
        public async Task<IActionResult> UpdateEquipmentType(EquipmentTypeUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<EquipmentTypeUpdateDTO>(request);

            if (await _manager.UpdateEquipmentType(dto))
                return StatusCode(202);

            throw new Exception();
        }

        //POST Equipment Type Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentType(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteEquipmentType(id))
                return StatusCode(207);

            throw new Exception();
        }
    }
}