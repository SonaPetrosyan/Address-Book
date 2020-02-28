using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Filters
{
    /// <summary>
    /// Base class for filter classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FilterBase<T> where T:class
    {
        #region Ctor
        protected FilterBase()
        {

        }
        #endregion
        #region Fields
        public abstract IQueryable<T> Filter(IQueryable<T> query);
        #endregion
    }
}
