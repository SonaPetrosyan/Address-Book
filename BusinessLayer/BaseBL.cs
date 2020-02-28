using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Base class for business logic classes
    /// </summary>
    public class BaseBL:IBaseBL
    {
        #region Ctor
        public BaseBL(IBLFactory blFactory)
        {
            this.blFactory = blFactory;
        }
        #endregion
        #region Properties
        private readonly IBLFactory blFactory;

        private IDataRepository _repository;
        public IDataRepository Repository
        {
            get
            {
                return this._repository ?? (this._repository = this.blFactory.RepositoryFactory.CreateDataRepository());
            }
        }

        public IBLFactory BLFactory => this.blFactory;
        #endregion
    }
}
