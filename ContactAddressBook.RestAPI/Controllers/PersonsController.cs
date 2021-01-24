using ContactAddressBook.Business.Abstract;
using ContactAddressBook.DataAccessLayer.Concrete.EntityFramework.Context;
using ContactAddressBook.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAddressBook.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personService.GetAllPersons();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _personService.GetPersonById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPost("add")]
        public IActionResult Add(Person  person)
        {
            var result = _personService.AddPerson(person);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("remove")]
        public IActionResult Remove(Person person)
        {
            var result = _personService.RemovePerson(person);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Person person)
        {
            var result = _personService.UpdatePerson(person);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

    }
}
