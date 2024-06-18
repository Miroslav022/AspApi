using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Country
{
    public class CreateCountryDtoValidator : AbstractValidator<NamedEntityDto>
    {
        public CreateCountryDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Country name is required")
                              .Must(x => !ctx.Countries.Any(c => c.Name == x)).WithMessage("Country already exists");
        }
    }
}
