using Exercice_API_01.Data;
using Exercice_API_01.Models;
using Exercice_API_01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exercice_API_01.Extensions;
using AutoMapper;
using Exercice_API_01.DTOs;
using System.Collections.Generic;

namespace Exercice_API_01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public ContactsController(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? name)
        {
            List<Contact> contacts = new List<Contact>();
            IEnumerable<ContactDTO> contactDTO = new List<ContactDTO>();
            if (name != null)
            {

                contacts = _repository.GetAll(x => x.FirstName.StartsWith(StringExtensions.RemoveDiacritics(name)));

                contactDTO = _mapper.Map<IEnumerable<ContactDTO>>(contacts);

                return Ok(new
                {
                    Message = "Contact trouvé",
                    Contact = contactDTO,
                });
            }
            contacts = _repository.GetAll();
            contactDTO = _mapper.Map<IEnumerable<ContactDTO>>(contacts);
            return Ok(contactDTO);
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
            ContactDTO contactDTO = _mapper.Map<ContactDTO>(contact);

            return Ok(new
            {
                Message = "Contact trouvé",
                Contact = contactDTO
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
            ContactDTO contactDTO = _mapper.Map<ContactDTO>(contact);

            return Ok(new
            {
                Message = "Contact trouvé",
                Contact = contactDTO
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContactDTO contactDTO)
        {
            var contact = _mapper.Map<Contact>(contactDTO);

            var contactAdded = _repository.Create(contact);

            var contactAddedDTO = _mapper.Map<ContactDTO>(contactAdded);

            if (contactAdded != null)
                return CreatedAtAction(nameof(GetById),
                    new { id = contactAddedDTO.Id },
                    new
                    {
                        Message = "Contact added",
                        Contact = contactAddedDTO
                    });
            _repository.Create(contact);

            return BadRequest("Something went wrong...");
        }

        [HttpPut("{id}")]
        //public IActionResult Put([FromRoute] int id, [FromBody] Contact contact)
        //{
        //    var contactToUpdate = _repository.Get(c => c.Id == id);

        //    if (contact.Id != id)
        //        return BadRequest("Different contact Id");


        //    if (contactToUpdate == null)
        //        return NotFound($"Employee with Id : {id} not found");

        //    contact.Id = id;

        //    var updatedContact = _repository.Update(contact);


        //    return Ok(new
        //    {
        //        Message = "Contact trouvé",
        //        Contact = updatedContact
        //    }); ;
        //}


        [HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    var contact = GetById(id);
        //    if (contact == null)
        //        return NotFound();
        //    _repository.Delete(id);
        //    return Ok(new
        //    {
        //        Message = "Contact Supprimé",
        //    }); ;

        //}
    }
}
