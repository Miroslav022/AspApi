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
    internal class CartConfiguration : EntityConfiguration<Cart>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Carts)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
