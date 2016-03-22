using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Entities
{
    public class ActivityModel
    {
        public int ActivityID { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MinBuyers { get; set; }
        public int CurrentBuyers { get; set; }

        public bool IsComplete { get { return DateTime.Now > EndTime; } }
        public bool IsCanceled { get { return CurrentBuyers < MinBuyers && DateTime.Now > EndTime; } }

        public int CategoryID { get; set; }
        public virtual CategoryModel Category { get; set; }

        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }

        public ActivityModel()
        {

        }
    }
}