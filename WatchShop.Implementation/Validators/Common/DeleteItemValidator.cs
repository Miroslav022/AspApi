using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;

namespace WatchShop.Implementation.Validators.Common
{
    public class DeleteItemValidator<TEntity> : AbstractValidator<DeleteDto>
        where TEntity : Entity
    {
        public DeleteItemValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => ctx.Set<TEntity>().Any(b => b.Id == x)).WithMessage($"Wrong id, {typeof(TEntity).Name} doesn't exist");
        }
    }
}
