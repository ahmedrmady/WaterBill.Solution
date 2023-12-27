
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.DAL.Data.Entities.Configurations
{
    public  class SubscriptionFileConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("NWC_Subscription_File");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Id")
                .IsFixedLength();

            entity.Property(e => e.IsThereSanitation)
                .HasColumnName("NWC_Subscription_File_Is_There_Sanitation");

            entity.Property(e => e.LastReadingMeter)
                .HasColumnName("NWC_Subscription_File_Last_Reading_Meter");

            entity.Property(e => e.Reasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("NWC_Subscription_File_Reasons");

            

            

            entity.Property(e => e.UnitNo)
                .HasColumnName("NWC_Subscription_File_Unit_No");


            entity.Property(e => e.RrealEstateTypesCode)
                  .IsRequired()
                  .HasColumnName("NWC_Subscription_File_Rreal_Estate_Types_Code");

            entity.Property(e => e.SubscriberCode)
                  .IsRequired()
                  .HasColumnName("NWC_Subscription_File_Subscriber_Code");

            //ReltationShipe Confugration
            entity.HasOne(d => d.RrealEstateType)
                .WithMany(p=>p.SubscriptionFiles)
                .HasForeignKey(d => d.RrealEstateTypesCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Subscription_File_NWC_Rreal_Estate_Types")
                ;

            entity.HasOne(d => d.Subscriber)
                .WithMany(p=>p.SubscriptionFiles)
                .HasForeignKey(d => d.SubscriberCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NWC_Subscription_File_NWC_Subscriber_File");

         
        }

       
    }
}
