using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRenterCore.API.DataContract.Equipment;
using ToolRenterCore.Business.DataContract.Equipment;

namespace ToolRenterCore.API.Controllers.Equipment
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentManager _manager;

        public EquipmentController(IMapper mapper, IEquipmentManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> PostEquipment([FromForm]EquipmentCreateRequest request)
        {
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var dto = _mapper.Map<EquipmentCreateDTO>(request);
            dto.OwnerId = identityClaimNum;
            dto.CreatedUtc = DateTime.Now;

            if (await _manager.CreateEquipment(dto))
                return StatusCode(201);

            throw new Exception();
        }

        //GET All Equipment
        [HttpGet]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetEquipment()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetEquipment();
            var response = _mapper.Map<IEnumerable<EquipmentGetListItemResponse>>(dto);

            return Ok(response); //Handle Exceptions
        }

        //GET Equipment Detail
        [HttpGet("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetEquipmentById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetEquipmentById(id);
            var response = _mapper.Map<EquipmentGetListItemResponse>(dto);

            return Ok(response);
        }

        //PUT Equipment Update
        [HttpPut]
        public async Task<IActionResult> UpdateSong([FromForm]EquipmentUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<EquipmentUpdateDTO>(request);
            dto.ModifiedUtc = DateTime.Now;

            if (await _manager.UpdateEquipment(dto))
                return StatusCode(202);

            throw new Exception();
        }

        //POST Equipment Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteEquipment(id))
                return StatusCode(207);

            throw new Exception();
        }
    }
}