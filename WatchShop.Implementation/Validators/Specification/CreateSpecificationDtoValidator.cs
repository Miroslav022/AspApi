using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Specification
{
    public class CreateSpecificationDtoValidator : AbstractValidator<NamedEntityDto>
    {
        public CreateSpecificationDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Specification name is required")
                              .Must(x => !ctx.Specifications.Any(c => c.Name == x)).WithMessage("Specification already exists");
        }
    }
}
