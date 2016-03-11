using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EIMS.Models
{
    public class RegisterUserViewModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Photo link")]
        public string photoLink { get; set; }

        public string Country { get; set; }

        [Display(Name = "State/Province")]
        public string StateOrProvince { get; set; }
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

    }
}