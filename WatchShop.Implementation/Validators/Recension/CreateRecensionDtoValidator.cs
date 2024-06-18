using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Recensions;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Recension
{
    public class CreateRecensionDtoValidator : AbstractValidator<CreateRecensionDto>
    {

        public CreateRecensionDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ProductId).NotEmpty()
                                   .WithMessage("Product is required")
                                   .Must(x => ctx.Products.Any(p => p.Id == x))
                                   .WithMessage("Product doesn't exit");


            RuleFor(x => x.Title).NotEmpty()
                               .WithMessage("Title is required");

            RuleFor(x => x.Description).NotEmpty()
                                       .WithMessage("Description is required");
        }
    }
}
