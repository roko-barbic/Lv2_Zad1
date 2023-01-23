using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
using Newtonsoft.Json;

namespace ContactManager.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        public ContactRepository(IHttpContextAccessor httpContextAccessor)
        {
            var ctx = httpContextAccessor.HttpContext;
            if (ctx != null)
            {
                var contacts = new Contact[]
                {
            new Contact { Id = 1, Name = "Glenn Block" },
            new Contact { Id = 2, Name = "Dan Roth" }
                };
                ctx.Session.SetString(CacheKey, JsonConvert.SerializeObject(contacts));
            }
        }

        public Contact[] GetAllContacts(IHttpContextAccessor httpContextAccessor)
        {
            var ctx = httpContextAccessor.HttpContext;
            if (ctx != null)
            {
                var contactsJson = ctx.Session.GetString(CacheKey);
                return JsonConvert.DeserializeObject<Contact[]>(contactsJson);
            }
            return new Contact[] { };
        }

    }
}
