using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.UserUseCasesDto;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.UserUseCaseValidator
{
    public class UserUseCaseDtoValidator : AbstractValidator<UserUseCaseDto>
    {
        public UserUseCaseDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId).Must(x => ctx.Users.Any(u => u.Id == x)).WithMessage("User doesn't exist");

            RuleFor(x => x.UseCaseIds).NotEmpty().WithMessage("Parameter is required")
                                      .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId)).WithMessage("Invalid usecase id range.")
                                      .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");
        }
    }
}
