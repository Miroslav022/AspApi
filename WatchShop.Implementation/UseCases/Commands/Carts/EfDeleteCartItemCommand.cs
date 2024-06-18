using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.Exceptions;
using WatchShop.Application.UseCases.Commands.Carts;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Common;

namespace WatchShop.Implementation.UseCases.Commands.Carts
{
    public class EfDeleteCartItemCommand : EFUseCase, IDeleteCartItemCommand
    {
        private readonly DeleteItemValidator<CartItem> _validator;
        public EfDeleteCartItemCommand(AspContext context, DeleteItemValidator<CartItem> validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => GetType().Name;

        public void Execute(DeleteDto data)
        {
            _validator.ValidateAndThrow(data);

            CartItem cartItemToDelete = Context.CartItems.FirstOrDefault(x=>x.Id == data.Id);
            if(cartItemToDelete != null)
            {
                Context.CartItems.Remove(cartItemToDelete);
                Context.SaveChanges();
            }else
            {
                throw new EntityNotFoundException(nameof(CartItem));
            }
        }
    }
}
