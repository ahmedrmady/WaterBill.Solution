using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.DAL.Data.Entities.Configurations
{
    public  class SubscriberFileConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> entity)
        {
            entity.ToTable("NWC_Subscriber_File")
                .HasKey(e=>e.Id);
          
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Id")
                .IsFixedLength();

            entity.Property(e => e.Area)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("NWC_Subscriber_File_Area");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("NWC_Subscriber_File_City");

            entity.Property(e => e.Mobile)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NWC_Subscriber_File_Mobile");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("NWC_Subscriber_File_Name");

            entity.Property(e => e.Reasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("NWC_Subscriber_File_Reasons");

           
        }

    }
}
