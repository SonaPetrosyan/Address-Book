using AddressBook.DataAccessLayer.DAL;
using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using DataAccessLayer.EntityRepositories.Base;
using DataAccessLayer.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityRepositories
{
    /// <summary>
    /// Repository class for contact entity
    /// </summary>
    public class ContactEntityRepository:BaseEntityRepository<Contact,ContactFilter>,IEntityRepository<Contact, ContactFilter>
    {
        #region Ctor
        public ContactEntityRepository(AddressBookDbEntities context):base(context)
        {

        }
        #endregion
    }
}
