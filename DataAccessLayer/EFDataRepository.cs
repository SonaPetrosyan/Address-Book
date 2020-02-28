using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.DataAccessLayer.DAL;
using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using DataAccessLayer.EntityRepositories;
using DataAccessLayer.EntityRepositories.Base;
using DataAccessLayer.Models.Filters;

namespace DataAccessLayer
{
    /// <summary>
    /// Entity framework data repository class
    /// </summary>
    public class EFDataRepository : IDataRepository
    {
        #region Fields
        internal AddressBookDbEntities _db;
        #endregion
        #region Ctor
        public EFDataRepository(AddressBookDbEntities context)
        {           
            this._db = context;
        }
        #endregion
        #region Repositories
        private IEntityRepository<Contact,ContactFilter> _contactRepository;
        public IEntityRepository<Contact, ContactFilter> ContactRepository
        {
            get
            {
                if (_contactRepository==null)
                {
                    _contactRepository = new ContactEntityRepository(this._db);
                }
                return _contactRepository;
            }
        }
        #endregion
        #region Dispose
        private bool _disposed = false;
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed == false)
            {
                if (disposing)
                {
                    if (this._db != null)
                    {
                        this._db.Dispose();
                        this._db = null;
                    }
                    this._disposed = true;
                }
            }
        }
        #endregion
    }
}
