using Exercice_API_01.Data;
using Exercice_API_01.Models;
using Exercice_API_01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercice_API_01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact> _repository;

        public ContactsController(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repository.GetById(id);

            if (contact == null)
                return NotFound(new
                {
                    Message = "Contact non trouvé"
                });

            return Ok(new
            {
                Message = "Contact trouvé",
                Contact = contact
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, "Contact ajouté");
        }
    }
}
