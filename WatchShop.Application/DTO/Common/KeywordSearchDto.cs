using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Common
{
    public class KeywordSearchDto : PagedSearch
    {
        public string? Keyword { get; set; }
    }
}
