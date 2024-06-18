using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Locations;
using WatchShop.Application.DTO.Orders;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.UseCases.Queries.Orders;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Orders
{
    public class EfGetOrdersQuery : EFUseCase, IGetOrdersQuery
    {
        public EfGetOrdersQuery(AspContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Search orders";

        public PagedResponse<OrderDto> Execute(OrderSearchDto search)
        {
            var query = Context.Orders.AsQueryable();
            if (!string.IsNullOrEmpty(search.Username))
            {
                query = query.Where(x => x.User.Username.Contains(search.Username));
            }
            if (!string.IsNullOrEmpty(search.Status))
            {
                query = query.Where(x => x.Status.Name.Contains(search.Status));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<OrderDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new OrderDto { 
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
                    Total = x.Total,
                    Status = x.Status.Name,
                    OrderItems = x.Products.Select(prod => new OrderItems
                    {
                        Id = prod.Id,
                        Name = prod.Price.Product.Name,
                        Price = prod.Price.Amount,
                        Quantity =prod.Quantity
                    }).ToList()
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
