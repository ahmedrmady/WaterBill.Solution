using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.DAL.Data.Entities.Configurations
{
    public  class RrealEstateTypeConfiguration : IEntityTypeConfiguration<RrealEstateType>
    {
        public void Configure(EntityTypeBuilder<RrealEstateType> entity)
        {
            

            entity.ToTable("NWC_Rreal_Estate_Types")
                  .HasKey(e => e.Code);

            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("NWC_Rreal_Estate_Types_Code")
                .IsFixedLength();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("nvarchar")
                .IsUnicode(false)
                .HasColumnName("NWC_Rreal_Estate_Types_Name");

            entity.Property(e => e.Reasons)
                
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("NWC_Rreal_Estate_Types_Reasons");

        }

    }
}
