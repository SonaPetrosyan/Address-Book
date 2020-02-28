using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ViewModels
{
    /// <summary>
    /// Model representing contact used for UI
    /// </summary>
    public class ContactVM
    {
        /// <summary>
        /// Unique id 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The full name is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "The full name is not valid")]
        public string FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "The phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The phone number is not valid. Sample: (895) 965-9545")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Physical address
        /// </summary>
        [Display(Name = "Physical Address")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "The physical address is not valid")]
        public string PhysicalAddress { get; set; }

    }
}
