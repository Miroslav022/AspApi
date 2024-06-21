using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Cities;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Queries.Cities;
using WatchShop.DataAccess;

namespace WatchShop.Implementation.UseCases.Queries.Cities
{
    public class EfGetCitiesQuery : EFUseCase, IGetCitiesQuery
    {
        public EfGetCitiesQuery(AspContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Search cities";

        public PagedResponse<CityDto> Execute(KeywordSearchDto search)
        {
            var query = Context.Cities.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CityDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new CityDto { 
                    Id = x.Id, 
                    City = x.Name,
                    Country = new NamedSearchDto
                    {
                        Name = x.Country.Name,
                        Id = x.Country.Id,
                    }
                }),
                PerPage = perPage,
                TotalCount = totalCount,
            }; ;
        }
    }
}
