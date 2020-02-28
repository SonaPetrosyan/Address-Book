using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ProxyModels
{
    /// <summary>
    /// Model representing contact used in data business layer
    /// </summary>
    public class ContactPO
    {
        /// <summary>
        /// Unique id for contact
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Full name of contact
        /// </summary>       
        public string FullName { get; set; }

        /// <summary>
        /// Email address of contact
        /// </summary>      
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number of contact
        /// </summary>       
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Physical address of contact
        /// </summary>      
        public string PhysicalAddress { get; set; }
    }
}
