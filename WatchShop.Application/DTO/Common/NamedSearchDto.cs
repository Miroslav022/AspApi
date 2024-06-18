using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Common
{
    public class NamedSearchDto : PagedSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
