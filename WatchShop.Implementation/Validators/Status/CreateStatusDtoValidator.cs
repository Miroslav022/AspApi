using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Statuses;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Status
{
    public class CreateStatusDtoValidator : AbstractValidator<NamedEntityDto>
    {
        public CreateStatusDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Status is required")
                                .Must(x => !ctx.Statuses.Any(s => s.Name == x))
                                .WithMessage("Status already exist");
        }
    }
}
