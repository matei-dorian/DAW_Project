using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities.Configurations
{
    public class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Desc)
              .HasColumnType("nvarchar(400)")
              .HasMaxLength(400);

            builder.Property(x => x.LastUpdate)
               .HasColumnType("date");

            builder.HasOne(x => x.Shoe)
              .WithOne(x => x.Description)
              .HasForeignKey<Description>(x => x.ShoeId);
        }
    }
}
