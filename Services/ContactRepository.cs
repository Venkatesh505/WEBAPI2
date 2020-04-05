using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPI2.Models;

namespace WEBAPI2.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        public ContactRepository()
            {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact
                        {
                            Id=1,Name="First"

                        },
                        new Contact
                        {
                            Id=2,Name="Second"

                        }
                    };
                    ctx.Cache[CacheKey] = contacts;
                }
            }
            }
        /*public Contact[] AllContacts => new Contact[]
            {
            new Contact
            {
                Id = 1,
                Name = "Glenn Block"
            },
            new Contact
            {
                Id = 2,
                Name = "Dan Roth"
            }
            }; */

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;
            if(ctx != null)
            {
                try
                {
                    var currentdata = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentdata.Add(contact);
                    ctx.Cache[CacheKey] = currentdata.ToArray();
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
            
        }
    }
}