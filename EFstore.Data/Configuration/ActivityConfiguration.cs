using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFstore.Entities;

namespace EFstore.Data.Configuration
{
    public class ActivityConfiguration : EntityTypeConfiguration<ActivityModel>
    {
        public ActivityConfiguration()
        {

        }
    }
}
