using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using ContactManager.Services;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository contactRepository;

        public ContactController(ContactRepository contactRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            //this.contactRepository.SaveContact(contact);

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }
    }
}
