using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities.Configurations
{
    public class ShoeOrderConfiguration : IEntityTypeConfiguration<ShoeOrder>
    {
        public void Configure(EntityTypeBuilder<ShoeOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Shoe)
                 .WithMany(x => x.ShoeOrders)
                 .HasForeignKey(x => x.ShoeId);
            
            builder.Property(x => x.Quantity)
                .HasPrecision(5, 0)
                .IsRequired();
            
            builder.HasOne(x => x.Order)
                .WithMany(x => x.ShoeOrders)
                .HasForeignKey(x => x.OrderId);

        }
    }
}
