using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.DataAccess.Configurations
{
    internal class LocationConfiguration : EntityConfiguration<Location>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x=>x.Address)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasOne(x => x.City)
                   .WithMany(x => x.Locations)
                   .HasForeignKey(x => x.CityId);
        }
    }
}
