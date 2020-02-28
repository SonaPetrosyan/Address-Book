using AddressBook.DataAccessLayer.Models.EntityModels;
using DataAccessLayer.Models.ProxyModels;
using DataAccessLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class Extensions
    {
        #region View models to proxy models
        public static ContactPO ToContactPO(this ContactVM contactVM)
        {
            return new ContactPO()
            {
                ID= contactVM.ID,
                FullName= contactVM.FullName,
                EmailAddress= contactVM.EmailAddress,
                PhoneNumber= contactVM.PhoneNumber,
                PhysicalAddress= contactVM.PhysicalAddress
            };
        }
        public static List<ContactPO> ToContactListPO(this List<Contact> contactList)
        {
            List<ContactPO> contactListPO = new List<ContactPO>();
            foreach (var contact in contactList)
            {
                contactListPO.Add(contact.ToContactPO());
            }
            return contactListPO;
        }
        #endregion
        #region Proxy models to entity models
        public static Contact ToEntityContact(this ContactPO contactPO)
        {
            return new Contact()
            {
                ID = contactPO.ID,
                FullName = contactPO.FullName,
                EmailAddress = contactPO.EmailAddress,
                PhoneNumber = contactPO.PhoneNumber,
                PhysicalAddress = contactPO.PhysicalAddress
            };
        }
        public static void ToEntityContactToUpdate(this ContactPO contactPO, ref Contact dbContact)
        {
            dbContact.FullName = contactPO.FullName;
            dbContact.EmailAddress = contactPO.EmailAddress;
            dbContact.PhoneNumber = contactPO.PhoneNumber;
            dbContact.PhysicalAddress = contactPO.PhysicalAddress;
        }

        #endregion
        #region Entity models to proxy models
        public static ContactPO ToContactPO(this Contact contact)
        {
            return new ContactPO()
            {
                ID = contact.ID,
                FullName = contact.FullName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                PhysicalAddress = contact.PhysicalAddress
            };
        }
        #endregion
        #region Entity models to view models
        public static ContactVM ToContactVM(this Contact contact)
        {
            return new ContactVM()
            {
                ID = contact.ID,
                FullName = contact.FullName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                PhysicalAddress = contact.PhysicalAddress
            };
        }
        #endregion
        #region Proxy models to view models
        public static ContactVM ToContactVM(this ContactPO contactPO)
        {
            return new ContactVM()
            {
                ID = contactPO.ID,
                FullName = contactPO.FullName,
                EmailAddress = contactPO.EmailAddress,
                PhoneNumber = contactPO.PhoneNumber,
                PhysicalAddress = contactPO.PhysicalAddress
            };
        }
        public static List<ContactVM> ToContactListVM(this List<ContactPO> contactListPO)
        {
            List<ContactVM> contactListVM= new List<ContactVM>();
            foreach (var contact in contactListPO)
            {
                contactListVM.Add(contact.ToContactVM());
            }
            return contactListVM;
        }
        #endregion
    }
}
