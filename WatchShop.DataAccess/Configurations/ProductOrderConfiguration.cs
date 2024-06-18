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
    internal class ProductOrderConfiguration : EntityConfiguration<ProductOrder>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Price)
                   .WithMany(x => x.ProductOrders)
                   .HasForeignKey(x => x.PriceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
