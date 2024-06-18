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
    internal class CityConfiguration : NamedEntityConfiguration<City>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(x => x.Country)
                   .WithMany(x => x.Cities)
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
