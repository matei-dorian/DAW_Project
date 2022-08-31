using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities.Configurations
{
    public class ShoeSizeConfiguration : IEntityTypeConfiguration<ShoeSize>
    {
        public void Configure(EntityTypeBuilder<ShoeSize> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .HasPrecision(5, 0)
                .IsRequired();

            builder.Property(x => x.Size)
                .HasPrecision(2, 0)
                .IsRequired();

            builder.HasOne(x => x.Shoe)
              .WithMany(x => x.ShoeSizes)
              .HasForeignKey(x => x.ShoeId); 
        }
    }
}
