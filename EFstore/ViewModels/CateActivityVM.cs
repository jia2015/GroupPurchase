using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFstore.Models;

namespace EFstore.ViewModels
{
    public class CateActivityVM
    {
        public List<CategoryModel> Categories { get; set; }

        public List<ActivityModel> Activities { get; set; }

        public CateActivityVM()
        {
            Categories = new List<CategoryModel>();
            Activities = new List<ActivityModel>();
        }
    }
}