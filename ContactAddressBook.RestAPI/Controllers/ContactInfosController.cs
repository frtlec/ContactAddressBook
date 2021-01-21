using ContactAddressBook.Business.Abstract;
using ContactAddressBook.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAddressBook.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {
        private IContactInfoService _contactInfoService;

        public ContactInfosController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet("removeall/{personId}")]
        public IActionResult RemoveByPersonId(int personId)
        {
            var result = _contactInfoService.RemoveAllContactByPersonId(personId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(ContactInfo contactInfo)
        {
            var result = _contactInfoService.AddContactInfo(contactInfo);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
