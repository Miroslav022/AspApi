using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Categories;
using WatchShop.Application.DTO.Common;

namespace WatchShop.Application.UseCases.Queries.Categories
{
    public interface ICategorySearchQuery : IQuery<PagedResponse<CategoryDto>, KeywordSearchDto>
    {
    }
}
