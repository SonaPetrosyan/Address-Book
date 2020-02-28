using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Interface for BL classes
    /// </summary>
    public interface IBaseBL
    {
        IBLFactory BLFactory { get; }
        IDataRepository Repository { get; }
    }
}
