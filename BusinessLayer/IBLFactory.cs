using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for BL factory class
    /// </summary>
    public interface IBLFactory
    {
        IDataRepositoryFactory RepositoryFactory { get; }
        ContactBL CreateContactBL();
    }
}
