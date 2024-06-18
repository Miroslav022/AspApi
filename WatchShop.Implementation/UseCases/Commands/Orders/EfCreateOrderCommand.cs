using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application;
using WatchShop.Application.DTO.Orders;
using WatchShop.Application.UseCases.Commands.Orders;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;
using WatchShop.Implementation.Validators.Order;

namespace WatchShop.Implementation.UseCases.Commands.Orders
{
    public class EfCreateOrderCommand : EFUseCase, ICreateOrderCommand
    {
        private readonly CreateOrderDtoValidation _validator;
        private readonly IApplicationActor _actor;
        public EfCreateOrderCommand(AspContext context, CreateOrderDtoValidation validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 11;

        public string Name => GetType().Name;

        public void Execute(CreateOrderDto data)
        {
           _validator.ValidateAndThrow(data);

            //Store cart in session
            var userCart = Context.Carts.Include(c=>c.CartItems).FirstOrDefault(x=>x.Id==data.CartId && !x.IsPurcheased);

            Order newOrder = new Order
            {
                UserId = _actor.Id,
                LocationId = 2,
                Total = Context.CartItems.Where(x => x.CartId == data.CartId).Sum(x => x.ProductPrice.Amount),
                StatusId = 1,
                Products = userCart.CartItems.Select(item=>new ProductOrder
                {
                    PriceId = item.PriceId,
                    Quantity = item.Quantity,
                }).ToList(),
            };

            userCart.IsPurcheased= true;
            
            Context.Orders.Add(newOrder);
            Context.SaveChanges();
        }
    }
}
