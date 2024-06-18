using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Brands;
using WatchShop.Application.UseCases.Queries.Brands;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Brands
{
    public class EfGetBrandsQuery : EFUseCase, IGetBrandsQuery
    {
        public EfGetBrandsQuery(AspContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Search Brands";

        public PagedResponse<BrandsDto> Execute(BrandSearch search)
        {
            var query = Context.Brands.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<BrandsDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new BrandsDto { Id = x.Id, Brand = x.Name }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
