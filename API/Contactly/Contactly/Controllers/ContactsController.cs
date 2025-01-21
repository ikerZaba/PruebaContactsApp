using System.ComponentModel.DataAnnotations;
using Contactly.Data;
using Contactly.Models;
using Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext  dbContext;
        public ContactsController(ContactlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult PostContact(AddContactRequestDTO requestDTO)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = requestDTO.Name,
                Email = requestDTO.Email,
                Phone = requestDTO.Phone,
                Favorite = requestDTO.Favorite
            };

            dbContext.Contacts.Add(domainModelContact);
            dbContext.SaveChanges();
            return Ok(domainModelContact);
        }
    }
}
