using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using EFstore.Models;

namespace EFstore.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserModel>
    {
        public UserMap()
        {
            HasKey(f => f.UserID);
            HasOptional(t => t.FundAccount).WithRequired(t => t.User).WillCascadeOnDelete(true);
        }
    }
}