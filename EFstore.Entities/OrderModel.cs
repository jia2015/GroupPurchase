using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Entities
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public bool IsFinished { get; set; }
        public decimal Total
        {
            get
            {
                decimal temp = 0;
                OrderDetails.ForEach(t => { temp += t.UnitPrice; });
                return temp;
            }
        }
        public bool IsValid(string activityId)
        {
            return !OrderDetails.Any(t => t.ActivityId == activityId);

        }

        public string UserID { get; set; }
        public virtual UserModel User { get; set; }

        public virtual List<OrderDetailModel> OrderDetails { get; set; }

        public OrderModel()
        {
            OrderDetails = new List<OrderDetailModel>();
        }
    }
}