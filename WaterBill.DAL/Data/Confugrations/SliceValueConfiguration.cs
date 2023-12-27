using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.DAL.Data.Entities.Configurations
{
    public  class SliceValueConfiguration : IEntityTypeConfiguration<SliceValue>
    {
        public void Configure(EntityTypeBuilder<SliceValue> entity)
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("NWC_Default_Slice_Values");

            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("NWC_Default_Slice_Values_Code")
                .IsFixedLength();

            entity.Property(e => e.Condition)
                .HasColumnName("NWC_Default_Slice_Values_Condtion");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("NWC_Default_Slice_Values_Name");

            entity.Property(e => e.Reasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NWC_Default_Slice_Values_Reasons");

            entity.Property(e => e.SanitationPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("NWC_Default_Slice_Values_Sanitation_Price");

            entity.Property(e => e.WaterPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("NWC_Default_Slice_Values_Water_Price");

         
        }

    }
}
