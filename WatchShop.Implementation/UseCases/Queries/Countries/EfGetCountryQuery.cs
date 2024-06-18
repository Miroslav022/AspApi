using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Categories;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Queries.Countries;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Countries
{
    public class EfGetCountryQuery : EFUseCase, IGetCountryQuery
    {
        public EfGetCountryQuery(AspContext context) : base(context)
        {
        }

        public int Id =>29;

        public string Name => "Search countries";

        public PagedResponse<NamedSearchDto> Execute(KeywordSearchDto search)
        {
            var query = Context.Countries.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<NamedSearchDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new NamedSearchDto { Id = x.Id, Name = x.Name }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
