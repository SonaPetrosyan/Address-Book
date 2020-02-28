using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using DataAccessLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Factory class for BL
    /// </summary>
    public class ContactBLFactory : IBLFactory
    {
        #region Properties
        public IDataRepositoryFactory RepositoryFactory { get; private set; }
        public ILogWriter LogWriter;
        #endregion
        #region Ctor
        public ContactBLFactory(IDataRepositoryFactory repositoryFactory, ILogWriter logWriter)
        {
            this.RepositoryFactory = repositoryFactory;
            this.LogWriter = logWriter;
        }
        #endregion
        #region Public Methods
        public ContactBL CreateContactBL()
        {
            return new ContactBL(this, this.LogWriter);           
        }
        #endregion
    }
}

