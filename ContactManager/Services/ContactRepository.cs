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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CacheKey = "ContactStore";

        public ContactRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Contact[] GetAllContacts()
        {
            var ctx = _httpContextAccessor.HttpContext;
            if (ctx != null)
            {
                var contactsJson = ctx.Session.GetString(CacheKey);
                return JsonConvert.DeserializeObject<Contact[]>(contactsJson);
            }
            return new Contact[] { };
        }
    }

}
