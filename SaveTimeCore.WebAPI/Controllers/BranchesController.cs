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
    public class BranchesController : ControllerBase
    {
        private readonly IService<Branch, BranchDTO, BranchResource> _service;
        private readonly IMapper _mapper;
        public BranchesController(IService<Branch, BranchDTO, BranchResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<BranchResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public BranchResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BranchResource branchResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var brancDto = _mapper.Map<BranchDTO>(branchResource);
            _service.Add(brancDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BranchResource branchResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var branchDto = _mapper.Map<BranchDTO>(branchResource);
            branchDto.Id = id;
            _service.Update(branchDto);

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