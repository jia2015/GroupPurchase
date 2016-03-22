using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using EFstore.Entities;
using EFstore.Data.Configuration;

namespace EFstore.Data
{
    public class AccDbContext : DbContext
    {

        public DbSet<UserModel> Users { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<ActivityModel> Activities { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<OrderDetailModel> OrderDetails { get; set; }

        public DbSet<FundModel> fundAccounts { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new FundConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}