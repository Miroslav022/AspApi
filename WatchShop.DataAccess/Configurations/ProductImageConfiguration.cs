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
    internal class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.ImageId });

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Image)
                   .WithMany(x => x.ProductImages) 
                   .HasForeignKey(x => x.ImageId);
        }
    }
}
