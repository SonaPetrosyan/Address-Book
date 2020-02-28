using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using DataAccessLayer.EntityRepositories.Base;
using DataAccessLayer.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Interface for data repository class
    /// </summary>
    public interface IDataRepository : IDisposable
    {
        IEntityRepository<Contact,ContactFilter> ContactRepository { get; }
    }
}
