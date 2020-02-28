using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.DataAccessLayer.DAL;
using BusinessLayer.Helpers;
using DataAccessLayer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AddressBook.Controllers
{
    /// <summary>
    /// Controller for contact related requests
    /// </summary>
    public class ContactsController : BaseController
    {
        #region Ctor
        public ContactsController(AddressBookDbEntities context) :base(context) { }
        #endregion
        #region Public Methods
        
        /// <summary>
        /// Get contacts
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Get()
        {
            var contactList = await ContactBLFactory.CreateContactBL().GetContactsAsync(null);
            return View(contactList.ToContactListVM());
        }

        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {           
            var dbContact = await ContactBLFactory.CreateContactBL().GetContactByIdAsync(id);
            if (dbContact == null)
            {
                return NotFound();
            }

            return View(dbContact.ToContactVM());
        }

        /// <summary>
        /// Create contact
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create contact post
        /// </summary>
        /// <param name="contactVM"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,EmailAddress,PhoneNumber,PhysicalAddress")] ContactVM contactVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ContactBLFactory.CreateContactBL().CreateContactAsync(contactVM.ToContactPO());
                }
                catch (Exception ex)
                {
                    this.Logger.WriteLog(ex);
                    throw ex;
                }
                return RedirectToAction(nameof(Get));
            }
            return View(contactVM);
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {          
            var dbContact = await ContactBLFactory.CreateContactBL().GetContactByIdAsync(id);
            if (dbContact == null)
            {
                return NotFound();
            }
            return View(dbContact.ToContactVM());
        }

        /// <summary>
        /// Edit contact post
        /// </summary>
        /// <param name="contactVM"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,FullName,EmailAddress,PhoneNumber,PhysicalAddress")] ContactVM contactVM)
        {           
            if (ModelState.IsValid)
            {               
                try
                {
                    await ContactBLFactory.CreateContactBL().UpdateContactAsync(contactVM.ToContactPO());
                }
                catch(Exception ex)
                {
                    this.Logger.WriteLog(ex);
                    throw ex;
                }
                return RedirectToAction(nameof(Get));
            }
            return View(contactVM);
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {           
            var dbContact = await ContactBLFactory.CreateContactBL().GetContactByIdAsync(id);
            if (dbContact == null)
            {
                return NotFound();
            }
            return View(dbContact.ToContactVM());
        }

        /// <summary>
        /// Delete contact confirmation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbContact = await ContactBLFactory.CreateContactBL().GetContactByIdAsync(id);
            try
            {
                await ContactBLFactory.CreateContactBL().DeleteContactAsync(dbContact);
            }
            catch (Exception ex)
            {
                this.Logger.WriteLog(ex);
                throw ex;
            }
            return RedirectToAction(nameof(Get));
        }
        #endregion

    }
}
