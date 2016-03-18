using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFstore.Models
{
    public class OrderDetailModel
    {
        [Key]
        public int OrderDetailID { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }     
        public string OrderID { get; set; }
        public virtual OrderModel Order { get; set; }

        public bool IsClosed { get; set; }

        public string ActivityId { get; set; }
        
    }
}