using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Carts;
using WatchShop.Application.UseCases.Commands.Carts;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Cart;

namespace WatchShop.Implementation.UseCases.Commands.Carts
{
    public class EfAddToCartCommand : EFUseCase, IAddToCartCommand
    {
        private readonly AddToCartDtoValidator _validator;
        public EfAddToCartCommand(AspContext context, AddToCartDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => GetType().Name;

        public void Execute(AddToCartDto data)
        {
            _validator.ValidateAndThrow(data);

            
            Cart userCartIfExists = Context.Carts.FirstOrDefault(x => x.UserId == data.UserId && !x.IsPurcheased);

            if(userCartIfExists == null)
            {
                CartItem cartItem = new CartItem
                {
                    Quantity = data.Quantity,
                    PriceId = data.PriceId,
                    Cart = new Cart
                    {
                        UserId = data.UserId,
                        IsPurcheased = false,
                    }
                };
                Context.CartItems.Add(cartItem);
                Context.SaveChanges();
            } else
            {
                CartItem cartItem = new CartItem
                {
                    Quantity = data.Quantity,
                    PriceId = data.PriceId,
                    Cart = userCartIfExists
                };
                Context.CartItems.Add(cartItem);
                Context.SaveChanges();
            }

        }
    }
}
