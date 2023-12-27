using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WaterBill.DAL.Data.Entities;

namespace WaterBill.DAL.Data.Entities.Configurations
{
    public  class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("NWC_Invoices");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NWC_Invoices_No")
                .IsFixedLength();

            entity.Property(e => e.AmountConsumption)
                .HasColumnName("NWC_Invoices_Amount_Consumption");

            entity.Property(e => e.ConsumptionValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Consumption_Value");

            entity.Property(e => e.CurrentConsumptionAmount)
                .HasColumnName("NWC_Invoices_Current_Consumption_Amount");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_Date");

            entity.Property(e => e.From)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_From");

            entity.Property(e => e.IsThereSanitation)
                .HasColumnName("NWC_Invoices_Is_There_Sanitation");

            entity.Property(e => e.PreviousConsumptionAmount)
                .HasColumnName("NWC_Invoices_Previous_Consumption_Amount");

            

            entity.Property(e => e.ServiceFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Service_Fee");


            entity.Property(e => e.TaxRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Tax_Rate");

            entity.Property(e => e.TaxValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Tax_Value");

            entity.Property(e => e.To)
                .HasColumnType("date")
                .HasColumnName("NWC_Invoices_To");

            entity.Property(e => e.TotalBill)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Total_Bill");

            entity.Property(e => e.TotalInvoice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Total_Invoice");

            entity.Property(e => e.Reasons)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("NWC_Invoices_Total_Reasons");

            entity.Property(e => e.WastewaterConsumptionValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NWC_Invoices_Wastewater_Consumption_Value");

            entity.Property(e => e.Year)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("NWC_Invoices_Year")
                .IsFixedLength();

            entity.Property(e => e.RrealEstateTypeCode)
                  .IsRequired()
                  .HasColumnName("NWC_Invoices_Rreal_Estate_Types");

            entity.Property(e => e.SubscriberId)
                  .IsRequired()
                  .HasColumnName("NWC_Invoices_Subscriber_No");

            entity.Property(e => e.SubscriptionId)
                  .IsRequired()
                  .HasColumnName("NWC_Invoices_Subscription_No");

            //ReltationShipe Confugration
            entity.HasOne(e => e.Subscription)
                   .WithMany()
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasForeignKey(e=>e.SubscriptionId);


            entity.HasOne(e => e.Subscriber)
                   .WithMany()
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasForeignKey(e=>e.SubscriberId);
            entity.HasOne(e => e.RrealEstateType)
                  .WithMany()
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasForeignKey(e => e.RrealEstateTypeCode);
                  

        }

        
    }
}
