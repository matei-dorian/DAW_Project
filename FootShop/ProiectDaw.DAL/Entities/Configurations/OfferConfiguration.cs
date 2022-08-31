using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities.Configurations
{
    class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Discount)
                .HasPrecision(2, 0)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(x => x.Shoe)
              .WithMany(x => x.Offers)
              .HasForeignKey(x => x.ShoeId);

        }
    }
}
