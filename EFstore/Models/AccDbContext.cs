using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EFstore.Models;
using System.Data.Entity;
using EFstore.Mapping;

namespace EFstore.Models
{
    public class AccDbContext : DbContext
    {

        public DbSet<UserModel> Users { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<ActivityModel> Activities { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<OrderDetailModel> OrderDetails { get; set; }

        public DbSet<FundModel> fundAccounts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new FundMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}