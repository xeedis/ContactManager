using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ContactsController: BaseApiController
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IContactsRepository _contactsRepository;
        public ContactsController(DataContext dataContext, IContactsRepository contactsRepository,IMapper mapper)
        {
            _dataContext = dataContext;
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _contactsRepository.GetConactsAsync();

            return Ok(contacts);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ContactDto>> GetContact(string name)
        {
            var contact = await _contactsRepository.GetContactByName(name);

            var contactDto = new ContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Password = contact.Password,
                CategoryId = contact.Category.Id,
                Category = new CategoryTypeDto
                {
                    Id = contact.Category.Id,
                    Name = contact.Category.Name,
                    Subcategory = contact.Category.Subcategory == null? null :
                    new SubcategoryDto
                    { 
                        Id = contact.Category.Subcategory.Id,
                        Name = contact.Category.Subcategory.Name
                    }
                },
                BirthDate = contact.BirthDate,
                Phone = contact.Phone
            };
            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(ContactDto contactDto)
        {
            var existingMail = await _dataContext.Contacts.AnyAsync(x => x.Email == contactDto.Email);

            if (existingMail) return BadRequest("Contact with that Email already exists!");

            var contact = _mapper.Map<Contact>(contactDto);

            _contactsRepository.AddContact(contact);
            if (await _contactsRepository.SaveAllAsync()) return Ok();
            return BadRequest("Could not create new contact");
        }

        [HttpPut("name")]
        public async Task<ActionResult<ContactUpdateDto>> UpdateContact(ContactUpdateDto contactUpdateDto, string name)
        {
            var contact = await _contactsRepository.GetContactByName(name);
            
            _mapper.Map(contactUpdateDto, contact); 

            if (await _contactsRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update contact");
        }

        [HttpDelete("name")]
        public async Task<ActionResult> DeleteContact(string name)
        {
            var contact = await _contactsRepository.GetContactByName(name);

            if (contact == null) return NotFound();

            _contactsRepository.DeleteContact(contact);

            if (await _contactsRepository.SaveAllAsync()) return Ok();

            return BadRequest("Couldn`t delete contact");
        }
    }
}
