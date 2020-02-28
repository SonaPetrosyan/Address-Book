using AddressBook.DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Factory class for data repository
    /// </summary>
    public class DataRepositoryFactory: IDataRepositoryFactory
    {
        #region Properties
        private readonly AddressBookDbEntities _db;
        #endregion
        #region Ctor
        public DataRepositoryFactory(AddressBookDbEntities context)
        {
            this._db = context;
        }
        #endregion
        #region Public Methods
        public IDataRepository CreateDataRepository()
        {
            return new EFDataRepository(this._db);
        }
        #endregion
    }
}
