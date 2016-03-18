using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFstore.Models;
using System.Data.Entity.ModelConfiguration;

namespace EFstore.Mapping
{
    public class FundMap : EntityTypeConfiguration<FundModel>
    {
        public FundMap()
        {
            HasKey(f => f.UserID);
        }
    }
}