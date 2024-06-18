using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Common;

namespace WatchShop.Application.UseCases.Queries.Specifications
{
    public interface IGetSpecificationsQuery : IQuery<PagedResponse<NamedSearchDto>, KeywordSearchDto>
    {
    }
}
