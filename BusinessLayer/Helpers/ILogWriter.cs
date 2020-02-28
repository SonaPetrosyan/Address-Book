using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    /// <summary>
    /// Interface for log classes
    /// </summary>
    public interface ILogWriter
    {
        void WriteLog(Exception exception);
    }
}
