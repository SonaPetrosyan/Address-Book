using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    /// <summary>
    /// Class for logs
    /// </summary>
    public class LogWriter:ILogWriter
    {
        #region Singleton
        private static readonly object SyncObject = new object();
        private static LogWriter _instance;
        public static ILogWriter GetInstance()
        {
            if (_instance==null)
            {
                lock (SyncObject)
                {
                    if (_instance==null)
                    {
                        _instance = new LogWriter();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Write log
        /// </summary>
        /// <param name="exception"></param>
        public void WriteLog(Exception exception)
        {
            try
            {
                var sb = new StringBuilder();
                var strDate = DateTime.Now.ToShortDateString();
                sb.Append(strDate+":");
                sb.Append(exception.Message.ToString());
            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
}
