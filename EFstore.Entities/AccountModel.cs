using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Entities
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        public virtual FundModel FundAccount { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }

        public UserModel()
        {
        }
    }
}