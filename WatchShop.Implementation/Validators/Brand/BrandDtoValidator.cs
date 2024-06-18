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
    public class BrandDtoValidator : AbstractValidator<NamedEntityDto>
    {
        public BrandDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Brand name is required")
                                .Must(x => !ctx.Brands.Any(b => b.Name.ToLower() == x.ToLower()))
                                .WithMessage("Brand already exists")
                                .MinimumLength(3)
                                .WithMessage("Brand name must contain at least 3 characters");
                                
        }
    }
}
