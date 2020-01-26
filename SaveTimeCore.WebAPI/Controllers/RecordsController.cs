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
    public class RecordsController : ControllerBase
    {
        private readonly IService<Record, RecordDTO, RecordResource> _service;
        private readonly IMapper _mapper;
        public RecordsController(IService<Record, RecordDTO, RecordResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<RecordResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public RecordResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] RecordResource recordResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var recordDto = _mapper.Map<RecordDTO>(recordResource);
            _service.Add(recordDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RecordResource recordResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var recordDto = _mapper.Map<RecordDTO>(recordResource);
            recordDto.Id = id;
            _service.Update(recordDto);

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