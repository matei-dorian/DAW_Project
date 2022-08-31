using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities.Configurations
{
    public class ShoeConfiguration : IEntityTypeConfiguration<Shoe>
    {
       
        public void Configure(EntityTypeBuilder<Shoe> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .HasColumnType("nvarchar(200)")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Brand)
              .HasColumnType("nvarchar(40)")
              .HasMaxLength(40);

            builder.Property(x => x.Colour)
              .HasColumnType("nvarchar(30)")
              .HasMaxLength(30);

            builder.Property(x => x.Category)
              .HasColumnType("nvarchar(30)")
              .HasMaxLength(30);

            builder.Property(x => x.Type)
              .HasColumnType("nvarchar(30)")
              .HasMaxLength(30);

            builder.Property(x => x.Price)
              .HasColumnType("decimal(8, 2)")
              .IsRequired();

            builder.Property(x => x.Image)
             .HasColumnType("nvarchar(300)")
             .HasMaxLength(300);


        }
    }
}
