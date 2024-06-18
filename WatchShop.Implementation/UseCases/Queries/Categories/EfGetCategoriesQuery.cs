using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Brands;
using WatchShop.Application.DTO.Categories;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Queries.Categories;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoriesQuery : EFUseCase, ICategorySearchQuery
    {
        public EfGetCategoriesQuery(AspContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Seach categories";

        public PagedResponse<CategoryDto> Execute(KeywordSearchDto search)
        {
            var query = Context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CategoryDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new CategoryDto { Id = x.Id, Category = x.Name }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
