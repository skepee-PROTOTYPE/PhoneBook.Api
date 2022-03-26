using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Api.Context;
using PhoneBook.Api.Services;

namespace PhoneBook.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookRepository phoneBookRepository;
        private readonly ILogger<PhoneBookController> logger;

        public PhoneBookController(IPhoneBookRepository _phoneBookRepository, ILogger<PhoneBookController> _logger)
        {
            phoneBookRepository = _phoneBookRepository;
            logger = _logger;
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("GET - PhoneBook.Api");
            var res = await phoneBookRepository.GetPhoneBooks();
            return Ok(res);
        }

        [HttpPost()]
        public IActionResult CreatePhoneBook([FromBody] PhoneBookNumber phonebook)
        {
            logger.LogInformation("POST - PhoneBook.Api");
            phoneBookRepository.AddPhoneBook(phonebook);
            return Ok(phonebook);
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePhoneBook(int id)
        {
            logger.LogInformation("DEL - PhoneBook.Api");
            phoneBookRepository.RemovePhoneBook(id);
            return NoContent();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePhoneBook([FromBody] PhoneBookNumber phonebook)
        {
            logger.LogInformation("PUT - PhoneBook.Api");
            var res = await phoneBookRepository.UpdatePhoneBook(phonebook);
            return Ok(res);
        }
    }
}
