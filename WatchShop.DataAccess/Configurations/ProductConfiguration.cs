using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.DataAccess.Configurations
{
    internal class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            

            builder.Property(x=>x.Name).IsRequired().HasMaxLength(120);
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.Category)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
