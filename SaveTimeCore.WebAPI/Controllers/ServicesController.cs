using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaveTimeCore.AbstractModels;
using SaveTimeCore.DataModels.Dictionary;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IService<Service, ServiceDTO, ServiceResource> _service;
        private readonly IMapper _mapper;
        public ServicesController(IService<Service, ServiceDTO, ServiceResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ServiceResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public ServiceResource GetService(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ServiceResource serviceResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var serviceDto = _mapper.Map<ServiceDTO>(serviceResource);
            _service.Add(serviceDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ServiceResource serviceResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var serviceDto = _mapper.Map<ServiceDTO>(serviceResource);
            serviceDto.Id = id;
            _service.Update(serviceDto);

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