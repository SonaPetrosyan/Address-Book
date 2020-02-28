using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.DataAccessLayer.DAL;
using BusinessLayer;
using BusinessLayer.Helpers;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    /// <summary>
    /// Base class for controllers
    /// </summary>
    public class BaseController : Controller
    {
        #region Properties
        private readonly AddressBookDbEntities Context;
        private readonly IDataRepositoryFactory RepositoryFactory;
        protected IBLFactory ContactBLFactory;
        protected ILogWriter Logger;
        #endregion
        #region Ctor
        public BaseController(AddressBookDbEntities context)
        {
            Context = context;
            Logger = LogWriter.GetInstance();
            RepositoryFactory = new DataRepositoryFactory(context);
            ContactBLFactory = new ContactBLFactory(RepositoryFactory, Logger);
        }
        #endregion
    }
}