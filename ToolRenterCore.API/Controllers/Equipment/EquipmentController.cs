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
        public async Task<IActionResult> PostSong([FromForm]EquipmentCreateRequest request)
        {
            //if (request.UploadedFile.ContentType != "audio/wave")
            //{
            //    return BadRequest("Wrong file type");
            //}

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var dto = _mapper.Map<EquipmentCreateDTO>(request);
            dto.OwnerId = identityClaimNum;
            dto.CreatedUtc = DateTime.Now;

            if (await _manager.CreateEquipment(dto))
                return StatusCode(201);

            throw new Exception();
        }
    }
}