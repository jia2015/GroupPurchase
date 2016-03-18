using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFstore.ViewModels
{
    public class OrderDetailVM
    {
        public string ActivityName { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        public string OrderDetailID { get; set; }
    }
}