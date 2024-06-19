
using WatchShop.Application;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Orders;
using WatchShop.Application.UseCases.Queries.Orders;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Orders
{
    public class EfMyOrdersQuery : EFUseCase, IGetMyOrdersQuery
    {
        private readonly IApplicationActor _actor;
        public EfMyOrdersQuery(AspContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 37;

        public string Name => "My orders";

        public PagedResponse<UserOrdersDto> Execute(MyOrdersSearchDto search)
        {
            var query = Context.Orders.AsQueryable();
            query = query.Where(x => x.UserId == _actor.Id);
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponse<UserOrdersDto>
            {
                CurrentPage = page,
                PerPage = perPage,
                Data = query.Select(x => new UserOrdersDto
                {
                    Id = x.Id,
                    Total = x.Total,
                    Status = x.Status.Name,
                    OrderItems = x.Products.Select(p => new OrderItems
                    {
                        Id = p.Id,
                        Name = p.Price.Product.Name,
                        Price = p.Price.Amount,
                        Quantity = p.Quantity,
                    }).ToList()
                }),
                TotalCount = totalCount,
            };
        }
    }
}
