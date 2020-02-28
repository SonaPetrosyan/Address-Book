using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Interface for data repository factory class
    /// </summary>
    public interface IDataRepositoryFactory
    {
        IDataRepository CreateDataRepository();
    }
}
