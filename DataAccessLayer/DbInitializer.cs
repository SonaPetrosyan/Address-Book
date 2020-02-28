using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataAccessLayer.DAL
{
    /// <summary>
    /// Initialize db with some data
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(AddressBookDbEntities context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
            {
                return; 
            }
            var contacts = new List<Contact>
            {
            new Contact{FullName="Dayanara Weber",EmailAddress="dprice@msn.com",PhoneNumber="(895) 965-9545",PhysicalAddress="57 Mulberry Street"},
            new Contact{FullName="Evelyn Wilkinson",EmailAddress="staikos@optonline.net",PhoneNumber="(810) 261-1031",PhysicalAddress="711 Saxon Lane"},
            new Contact{FullName="Abby Mccann",EmailAddress="psharpe@mac.com",PhoneNumber="(942) 393-9020",PhysicalAddress="850 Bayport St"},
            };
            foreach (var c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();          
        }
    }
}
