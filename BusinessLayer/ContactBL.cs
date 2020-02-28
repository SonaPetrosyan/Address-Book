using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using DataAccessLayer.Models.Filters;
using DataAccessLayer.Models.ProxyModels;
using BusinessLayer.Helpers;

namespace BusinessLayer
{
    /// <summary>
    /// Business logic class for contact
    /// </summary>
    public class ContactBL : BaseBL,IContactBL
    {
        #region Properties
        readonly ILogWriter LogWriter;
        #endregion
        #region Ctor
        public ContactBL(IBLFactory blFactory,ILogWriter logWriter):base(blFactory)
        {
            LogWriter = logWriter;
        }
        #endregion
        #region Public Methods
        public List<ContactPO> GetContacts(ContactFilter filter)
        {
            return this.Repository.ContactRepository.Get(filter).ToList().ToContactListPO();
        }
        public async Task<List<ContactPO>> GetContactsAsync(ContactFilter filter)
        {
            var contactList= await this.Repository.ContactRepository.GetAsync(filter);
            return contactList.ToContactListPO();
        }
        public Contact GetContactById(int id)
        {
            var contacts =  this.Repository.ContactRepository.Get(new ContactFilter() { Id = id });
            return contacts.FirstOrDefault();
        }
        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contacts= await this.Repository.ContactRepository.GetAsync(new ContactFilter() { Id = id });
            return contacts.FirstOrDefault();
        }
        public ContactPO CreateContact(ContactPO contactPO)
        {
            var dbContact = contactPO.ToEntityContact();
            return this.Repository.ContactRepository.Create(dbContact).ToContactPO();
        }
        public async Task<ContactPO> CreateContactAsync(ContactPO contact)
        {
            var dbContact = await this.Repository.ContactRepository.CreateAsync(contact.ToEntityContact());
            return dbContact.ToContactPO();
        }
        public ContactPO UpdateContact(ContactPO contactPO)
        {
            var dbContact = GetContactById(contactPO.ID);
            if (dbContact == null)
            {
                return null;
            }
            contactPO.ToEntityContactToUpdate(ref dbContact);
            var contact = this.Repository.ContactRepository.Update(dbContact);
            return dbContact.ToContactPO();
        }
        public async Task<ContactPO> UpdateContactAsync(ContactPO contactPO)
        {
            var dbContact = await GetContactByIdAsync(contactPO.ID);
            if (dbContact == null)
            {
                return null;
            }
            contactPO.ToEntityContactToUpdate(ref dbContact);      
            var contact = await this.Repository.ContactRepository.UpdateAsync(dbContact);
            return dbContact.ToContactPO();
        }
        public ContactPO DeleteContact(Contact contact)
        {
            var dbContact = this.Repository.ContactRepository.Delete(contact);
           return dbContact.ToContactPO();
        }
        public async Task<ContactPO> DeleteContactAsync(Contact contact)
        {
            var dbContact = await this.Repository.ContactRepository.DeleteAsync(contact);
            return dbContact.ToContactPO();
        }
        #endregion
    }
}
