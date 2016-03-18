using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFstore.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public int ActivitiesCount { get { return Activities.Count; } }
  
        public virtual ICollection<ActivityModel> Activities { get; set; }

        public CategoryModel()
        {
            Activities = new List<ActivityModel>();
        }
    }
}