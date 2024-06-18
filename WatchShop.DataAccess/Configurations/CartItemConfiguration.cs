using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.DataAccess.Configurations
{
    internal class CartItemConfiguration : EntityConfiguration<CartItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasOne(x => x.Cart)
                   .WithMany(x => x.CartItems)
                   .HasForeignKey(x => x.CartId);

            builder.HasOne(x => x.ProductPrice)
                   .WithMany(x => x.CartItems)
                   .HasForeignKey(x => x.PriceId);

            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
