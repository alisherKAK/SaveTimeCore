using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaveTimeCore.AbstractModels;
using SaveTimeCore.DataModels.Organization;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemAdminsController : ControllerBase
    {
        private readonly IService<SystemAdmin, SystemAdminDTO, SystemAdminResource> _service;
        private readonly IMapper _mapper;
        public SystemAdminsController(IService<SystemAdmin, SystemAdminDTO, SystemAdminResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<SystemAdminResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public SystemAdminResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SystemAdminResource systemAdminResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var systemAdminDto = _mapper.Map<SystemAdminDTO>(systemAdminResource);
            _service.Add(systemAdminDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SystemAdminResource systemAdminResource)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var systemAdminDto = _mapper.Map<SystemAdminDTO>(systemAdminResource);
            systemAdminDto.Id = id;
            _service.Update(systemAdminDto);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}