using EFstore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Data.Configuration
{
    public class FundConfiguration : EntityTypeConfiguration<FundModel>
    {
        public FundConfiguration()
        {
            HasKey(f => f.UserID);
        }
    }
}
