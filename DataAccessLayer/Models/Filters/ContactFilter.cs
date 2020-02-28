using AddressBook.DataAccessLayer.Models;
using AddressBook.DataAccessLayer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Filters
{
    /// <summary>
    /// Filter class for contact
    /// </summary>
    public class ContactFilter : FilterBase<Contact>
    {
        public int? Id { get; set; }
        public override IQueryable<Contact> Filter(IQueryable<Contact> query)
        {
            if (this.Id.HasValue)
            {
                query = query.Where(x => x.ID == this.Id);
            }
            return query;
        }
    }
}
