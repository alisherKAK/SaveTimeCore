using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaveTimeCore.AbstractModels;
using SaveTimeCore.DataModels.Business;
using SaveTimeCore.Domain.DTOs;
using SaveTimeCore.Domain.Resources;

namespace SaveTimeCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IService<Client, ClientDTO, ClientResource> _service;
        private readonly IMapper _mapper;
        public ClientsController(IService<Client, ClientDTO, ClientResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ClientResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public ClientResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ClientResource clientResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var clientDto = _mapper.Map<ClientDTO>(clientResource);
            _service.Add(clientDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientResource clientResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var clientDto = _mapper.Map<ClientDTO>(clientResource);
            clientDto.Id = id;
            _service.Update(clientDto);

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