using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Brand
{
    public class DeleteBrandDtoValidator : AbstractValidator<DeleteDto>
    {
        public DeleteBrandDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => ctx.Brands.Any(b => b.Id == x)).WithMessage("Wrong id, brand doesn't exist");
        }
    }
}
