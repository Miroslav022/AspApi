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
    internal class ImageConfiguration : EntityConfiguration<Image>
    {

        protected override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.path).IsRequired();
        }
    }
}
