using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFstore.Models;
using System.ComponentModel.DataAnnotations;

namespace EFstore.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(30, ErrorMessage = "{0} must have at least {2} characters.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterVM
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(30, ErrorMessage = "{0} must have at least {2} characters.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }
    }
}