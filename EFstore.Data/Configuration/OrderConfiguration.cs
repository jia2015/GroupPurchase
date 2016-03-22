using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using EFstore.Entities;

namespace EFstore.Data.Configuration
{
    class OrderConfiguration : EntityTypeConfiguration<OrderModel>
    {
        public OrderConfiguration()
        {

        }
    }
}
