using Exercice_API_01.Data;
using Exercice_API_01.Models;
using Exercice_API_01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exercice_API_01.Extensions;

namespace Exercice_API_01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IRepository<Contact> _repository;

        public ContactsController(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? name)
        {
            if (name != null)
            {
                //List<Contact> list = (List<Contact>)_repository.GetAll().Where(x => x.FirstName.StartsWith(name));

                List<Contact> contacts = _repository.GetAll(x => x.FirstName.StartsWith(StringExtensions.RemoveDiacritics(name)));

                return Ok(new
                {
                    Message = "Contact trouvé",
                    Contact = contacts
                });
            }
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repository.Get(contact => contact.Id == id);

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

        [HttpGet("/name/{lastName?}")]
        public IActionResult GetByName([FromRoute] string lastName)
        {
            var contact = _repository.Get(c => c.LastName == lastName);

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
            _repository.Create(contact);
            return Ok(new
            {
                Message = "Contact trouvé",
                Contact = contact
            }); ;
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,[FromBody] Contact contact)
        {
                var contactToUpdate = _repository.GetById(id);
            
                if (contact.Id != id)
                    return BadRequest("Different contact Id");


                if (contactToUpdate == null)
                    return NotFound($"Employee with Id : {id} not found");

            contact.Id = id;

            var updatedContact = _repository.Update(contact);


                return Ok(new
                {
                    Message = "Contact trouvé",
                    Contact = updatedContact
                }); ;

            
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        "Error updating data");
            //}
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var contact = GetById(id);
            if (contact == null)
                return NotFound();
            _repository.Delete(id);
            return Ok(new
            {
                Message = "Contact Supprimé",
            }); ;

        }
    }
}
