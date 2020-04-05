using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WEBAPI2.Models;
using WEBAPI2.Services;

namespace WEBAPI2.Controllers
{

    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController()
            {
            this.contactRepository = new ContactRepository();
            }
        [AcceptVerbs("GET","POST")]
        public Contact[] PullContacts()
        {
            var ctx = HttpContext.Current;
            if(ctx != null)
            {
                return (Contact[])ctx.Cache["ContactStore"];
            }
            return new Contact[]
        {
            new Contact
            {
                Id = 0,
                Name = "Placeholder"
            }
        };
            //return this.contactRepository.AllContacts;
        }
        
    }
}
