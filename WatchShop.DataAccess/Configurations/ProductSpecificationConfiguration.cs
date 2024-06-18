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
    internal class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SpecificationId });

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductSpecifications)
                   .HasForeignKey(x => x.ProductId);

            builder.HasOne(x=>x.Specification)
                   .WithMany(x => x.ProductSpecifications)
                   .HasForeignKey(x => x.SpecificationId);

            builder.Property(x => x.Value).IsRequired().HasMaxLength(50);
        }
    }
}
