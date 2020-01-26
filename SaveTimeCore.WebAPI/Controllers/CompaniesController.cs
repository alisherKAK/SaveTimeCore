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
    public class CompaniesController : ControllerBase
    {
        private readonly IService<Company, CompanyDTO, CompanyResource> _service;
        private readonly IMapper _mapper;
        public CompaniesController(IService<Company, CompanyDTO, CompanyResource> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CompanyResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public CompanyResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CompanyResource companyResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDTO>(companyResource);
            _service.Add(companyDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CompanyResource companyResource)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDTO>(companyResource);
            companyDto.Id = id;
            _service.Update(companyDto);

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delet(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}