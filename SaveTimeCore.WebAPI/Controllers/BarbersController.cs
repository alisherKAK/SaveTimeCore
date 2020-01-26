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
    public class BarbersController : ControllerBase
    {
        private readonly IService<Barber, BarberDTO, BarberResource> _service;
        private readonly IMapper _mapper;
        public BarbersController(IService<Barber, BarberDTO, BarberResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<BarberResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public BarberResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BarberResource barberResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var barberDto = _mapper.Map<BarberDTO>(barberResource);
            _service.Add(barberDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BarberResource barberResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var barberDto = _mapper.Map<BarberDTO>(barberResource);
            barberDto.Id = id;
            _service.Update(barberDto);

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