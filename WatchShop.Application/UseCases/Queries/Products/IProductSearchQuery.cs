using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Product;

namespace WatchShop.Application.UseCases.Queries.Products
{
    public interface IProductSearchQuery : IQuery<PagedResponse<ProductDto>, ProductSearch>
    {
    }
}
