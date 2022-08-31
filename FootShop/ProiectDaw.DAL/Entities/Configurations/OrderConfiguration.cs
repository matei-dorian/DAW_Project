using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Address)
              .HasColumnType("nvarchar(200)")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.City)
              .HasColumnType("nvarchar(50)")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(x => x.Distributor)
              .HasColumnType("nvarchar(50)")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(x => x.Price)
              .HasColumnType("decimal(9, 2)")
              .IsRequired();

            builder.Property(x => x.OrderDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.ShippingDate)
                .HasColumnType("date");

            builder.HasOne(x => x.User)
              .WithMany(x => x.Orders)
              .HasForeignKey(x => x.UserId);


        }
    }
}
