using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Carts;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Cart
{
    public class AddToCartDtoValidator : AbstractValidator<AddToCartDto>
    {
        public AddToCartDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x=>x.UserId).NotEmpty()
                                .WithMessage("User is required")
                                .Must(x=>ctx.Users.Any(u=>u.Id==x))
                                .WithMessage("User doesn't exist");

            RuleFor(x => x.UserId).NotEmpty()
                                .WithMessage("User is required")
                                .Must(x => ctx.Users.Any(u => u.Id == x))
                                .WithMessage("User doesn't exist");
            RuleFor(x => x.PriceId).NotEmpty()
                                .WithMessage("Product price is required")
                                .Must(x => ctx.Prices.Any(u => u.Id == x))
                                .WithMessage("Product doesn't exist");

            RuleFor(x => x.Quantity).NotEmpty()
                                  .WithMessage("Quantity is required")
                                  .GreaterThan(0)
                                  .WithMessage("Quantity must be at least 1");
        }
    }
}
