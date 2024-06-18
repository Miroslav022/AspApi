using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.DataAccess.Configurations
{
    internal class PriceConfiguration : EntityConfiguration<Price>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            builder.Property(x => x.Amount).IsRequired().HasPrecision(12, 2);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Prices)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
