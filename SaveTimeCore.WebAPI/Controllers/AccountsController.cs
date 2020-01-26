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
    public class AccountsController : ControllerBase
    {
        private readonly IService<Account, AccountDTO, AccountResource> _service;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        public AccountsController(IService<Account, AccountDTO, AccountResource> service, IMapper mapper, IEncrypter encrypter)
        {
            _service = service;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        [HttpGet]
        public List<AccountResource> GetAll()
        {
            return _service.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public AccountResource Get(int id)
        {
            return _service.Get(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AccountResource accountResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var accountDto = _mapper.Map<AccountDTO>(accountResource);
            accountDto.Password = _encrypter.HashPassword(accountDto.Password);
            _service.Add(accountDto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AccountResource accountResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var accountDto = _mapper.Map<AccountDTO>(accountResource);
            accountDto.Id = id;
            _service.Update(accountDto);

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