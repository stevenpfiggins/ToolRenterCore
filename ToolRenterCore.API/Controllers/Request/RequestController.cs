using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRenterCore.API.DataContract.Request;
using ToolRenterCore.Business.DataContract.Request.DTOs;
using ToolRenterCore.Business.DataContract.Request.Interfaces;

namespace ToolRenterCore.API.Controllers.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRequestManager _manager;

        public RequestController(IMapper mapper, IRequestManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> PostRequest(RequestCreateRequest request)
        {
            var dto = _mapper.Map<RequestCreateDTO>(request);
            dto.OwnerId = GetUser();
            dto.CreatedUtc = DateTime.Now;

            if (await _manager.CreateRequest(dto))
                return StatusCode(201);

            throw new Exception("Item could not be created.");
        }

        // GET All Requests
        [HttpGet]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetRequests()
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetRequest();
            var response = _mapper.Map<IEnumerable<RequestGetListItemResponse>>(dto);

            return Ok(response);
        }

        // GET Request Detail
        [HttpGet("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = await _manager.GetRequestById(id);
            var response = _mapper.Map<RequestGetListItemResponse>(dto);

            return Ok(response);
        }

        // PUT Request Update
        [HttpPut]
        public async Task<IActionResult> UpdateRequest(RequestUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var dto = _mapper.Map<RequestUpdateDTO>(request);
            dto.ModifiedUtc = DateTime.Now;

            if (await _manager.UpdateRequest(dto))
                return StatusCode(202);

            throw new Exception("Item could not be updated.");
        }

        // POST Request Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.DeleteRequest(id))
                return StatusCode(207);

            throw new Exception("Item could not be deleted.");
        }

        private int GetUser()
        {
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return identityClaimNum;
        }
    }
}