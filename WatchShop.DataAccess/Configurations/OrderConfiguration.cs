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
    internal class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Total).IsRequired().HasPrecision(12,2);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.StatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Location)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
