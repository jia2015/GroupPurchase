using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Entities
{
    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public decimal UnitPrice { get; set; }     
        public string OrderID { get; set; }
        public virtual OrderModel Order { get; set; }

        public bool IsClosed { get; set; }

        public string ActivityId { get; set; }
        
    }
}