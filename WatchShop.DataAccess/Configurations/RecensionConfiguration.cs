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
    internal class RecensionConfiguration : EntityConfiguration<Recension>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Recension> builder)
        {
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(200);

            builder.HasOne(x=>x.Product)
                   .WithMany(x=>x.Recensions)
                   .HasForeignKey(x=>x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Recensions)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
