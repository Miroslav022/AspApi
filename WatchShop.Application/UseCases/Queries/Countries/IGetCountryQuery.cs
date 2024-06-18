﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Common;

namespace WatchShop.Application.UseCases.Queries.Countries
{
    public interface IGetCountryQuery : IQuery<PagedResponse<NamedSearchDto>, KeywordSearchDto>
    {
    }
}
