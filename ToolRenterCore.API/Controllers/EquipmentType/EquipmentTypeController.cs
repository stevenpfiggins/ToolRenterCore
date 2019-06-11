using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRenterCore.API.DataContract.EquipmentType;
using ToolRenterCore.Business.DataContract.EquipmentType.DTOs;
using ToolRenterCore.Business.DataContract.EquipmentType.Interfaces;

namespace ToolRenterCore.API.Controllers.EquipmentType
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentTypeManager _manager;

        public EquipmentTypeController(IMapper mapper, IEquipmentTypeManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

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
    }
}