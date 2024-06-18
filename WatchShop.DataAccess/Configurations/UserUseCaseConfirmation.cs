﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Domain.Entities;

namespace WatchShop.DataAccess.Configurations
{
    internal class UserUseCaseConfirmation : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.UseCaseId
            });

            builder.HasOne(x => x.User)
                   .WithMany(x => x.UserUseCases)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
