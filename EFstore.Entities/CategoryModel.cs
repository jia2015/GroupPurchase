using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFstore.Entities
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int ActivitiesCount { get { return Activities.Count; } }
  
        public virtual ICollection<ActivityModel> Activities { get; set; }

        public CategoryModel()
        {
            Activities = new List<ActivityModel>();
        }
    }
}