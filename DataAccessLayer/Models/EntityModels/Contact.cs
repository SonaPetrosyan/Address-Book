using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DataAccessLayer.Models.EntityModels
{
    /// <summary>
    /// Model representing contact used in data access layer
    /// </summary>
    [Table("Contact")]
    public class Contact
    {
        /// <summary>
        /// Unique id 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
       
        public string FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>     
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>       
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Physical address
        /// </summary>     
        public string PhysicalAddress { get; set; }

    }
}
