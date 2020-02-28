using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using DataAccessLayer.Models.Filters;
using DataAccessLayer.Models.ProxyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for ContactBL class
    /// </summary>
    public interface IContactBL:IBaseBL
    {
        List<ContactPO> GetContacts(ContactFilter filter);
        Task<List<ContactPO>> GetContactsAsync(ContactFilter filter);
        Contact GetContactById(int id);
        Task<Contact> GetContactByIdAsync(int id);
        ContactPO CreateContact(ContactPO contact);
        Task<ContactPO> CreateContactAsync(ContactPO contact);
        ContactPO UpdateContact(ContactPO contactPO);
        Task<ContactPO> UpdateContactAsync(ContactPO contactPO);
        ContactPO DeleteContact(Contact contact);
        Task<ContactPO> DeleteContactAsync(Contact contact);
    }
}
