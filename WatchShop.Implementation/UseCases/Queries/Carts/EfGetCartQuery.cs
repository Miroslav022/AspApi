using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Carts;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Locations;
using WatchShop.Application.DTO.Orders;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.UseCases.Queries.Carts;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Carts
{
    public class EfGetCartQuery : EFUseCase, IGetCartsQuery
    {
        public EfGetCartQuery(AspContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Search carts";

        public PagedResponse<CartDto> Execute(CartSearchDto search)
        {
            var query = Context.Carts.AsQueryable();
            if (!string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(x => x.User.Username.Contains(search.Username));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CartDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new CartDto
                {
                    Id = x.Id,
                    User = new UserDto
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        Username = x.User.Username,
                        Email = x.User.Email,
                        Id = x.User.Id,
                        BirthDate = x.User.BirthDate,
                        Location = new LocationDto
                        {
                            City = x.User.Location.City.Name,
                            Country = x.User.Location.City.Country.Name,
                            Address = x.User.Location.Address
                        },
                        Image = new ImageDto
                        {
                            path = x.User.Image.path
                        },
                    },
                    Items = x.CartItems.Select(prod => new CartItemDto
                    {
                        Id = prod.Id,
                        Name = prod.ProductPrice.Product.Name,
                        Price = prod.ProductPrice.Amount,
                        Quantity = prod.Quantity,
                        BackgroudImage = prod.ProductPrice.Product.Images.First(i=>i.IsBackground).Image.path,
                    }).ToList()
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    
    }
}
