using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFstore.Models
{
    public class FundModel
    {

        public int? UserID { get; set; }
        public virtual UserModel User { get; set; }

        public decimal Balance { get; set; }

        public FundModel()
        {

        }
    }
}