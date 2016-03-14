using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EIMS.Models
{
    public class RegisterUserViewModel
    {
        public long ID { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Photo link")]
        public string photoLink { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "State/Province")]
        public string StateOrProvince { get; set; }
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

    }

    public class UserInfoViewModel
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }

    public class ChangeUserPasswordViewModel
    {
        public long ID { get; set; }

        [Display(Name = "User name")]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}