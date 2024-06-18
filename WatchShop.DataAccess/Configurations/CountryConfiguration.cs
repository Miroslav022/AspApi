using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.DataAccess.Configurations
{
    internal class CountryConfiguration : NamedEntityConfiguration<Country>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Country> builder)
        {
            
        }
    }
}
