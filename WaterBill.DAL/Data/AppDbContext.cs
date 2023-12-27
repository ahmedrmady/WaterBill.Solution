using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Reflection;
using WaterBill.DAL.Data.Entities.Configurations;
#nullable disable

namespace WaterBill.DAL.Data.Entities
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //excute all confugrations classes
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        }

        public virtual DbSet<SliceValue> DefaultSliceValues { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<RrealEstateType> RrealEstateTypes { get; set; }
        public virtual DbSet<Subscriber> SubscriberFiles { get; set; }
        public virtual DbSet<Subscription> SubscriptionFiles { get; set; }

    }
}
