using EFstore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<UserModel>
    {
        public UserConfiguration()
        {
            HasKey(f => f.UserID);
            HasOptional(t => t.FundAccount).WithRequired(t => t.User).WillCascadeOnDelete(true);
        }
    }
}
