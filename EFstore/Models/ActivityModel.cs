using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFstore.Models
{
    public class ActivityModel
    {
        [Key]
        public int ActivityID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Name")]
        public string ProductTitle { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Minimum number of people is required.")]
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