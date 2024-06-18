using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Brands;

namespace WatchShop.Application.UseCases.Queries.Brands
{
    public interface IGetBrandsQuery : IQuery<PagedResponse<BrandsDto>, BrandSearch>
    {
    }
}
