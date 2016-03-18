using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFstore.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(30, ErrorMessage = "{0} must have at least {2} characters.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserRole { get; set; }

        public virtual FundModel FundAccount { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }

        public UserModel()
        {
        }
    }
}