using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application;
using WatchShop.Application.DTO.Carts;
using WatchShop.Application.UseCases.Queries.Carts;
using WatchShop.DataAccess;
using WatchShop.Domain.Entities;

namespace WatchShop.Implementation.UseCases.Queries.Carts
{
    public class EfGetUserCartQuery : EFUseCase, IGetUserCartQuery
    {
        private readonly IApplicationActor _actor;
        public EfGetUserCartQuery(AspContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 35;

        public string Name => "Search cart";

        public UserCartDto Execute(int search)
        {
            Cart userCart = Context.Carts.FirstOrDefault(x => x.UserId == _actor.Id && !x.IsPurcheased);

            return new UserCartDto
            {
                CreatedAt = userCart.CreatedAt,
                Id = userCart.Id,
                Products = userCart.CartItems.Select(x => new CartItemDto
                {
                    Id = x.Id,
                    Price = x.ProductPrice.Amount,
                    Name = x.ProductPrice.Product.Name,
                    Quantity = x.Quantity,
                    BackgroudImage = x.ProductPrice.Product.Images.Any(x=>x.IsBackground) ? x.ProductPrice.Product.Images.First(x => x.IsBackground).Image.path : "default.png"
                }).ToList(),
            };

        }
    }
}
