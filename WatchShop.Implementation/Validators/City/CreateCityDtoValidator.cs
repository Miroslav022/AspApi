using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Cities;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.City
{
    public class CreateCityDtoValidator : AbstractValidator<CreateCityDto>
    {
        public CreateCityDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.City).NotEmpty()
                                .WithMessage("City is required")
                                .MinimumLength(5)
                                .WithMessage("City must have at least 5 characters");

            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country id is required")
                                     .Must(x => ctx.Countries.Any(c => c.Id == x)).WithMessage("Country does't exist");



        }
    }
}
