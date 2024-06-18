using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Orders;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.Validators.Order
{
    public class CreateOrderDtoValidation : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidation(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CartId).Must(x=>ctx.Carts.Any(c=>c.Id==x)).WithMessage("Cart doesn't exist");
        }
    }
}
