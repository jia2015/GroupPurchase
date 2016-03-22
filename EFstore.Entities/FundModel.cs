using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Entities
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