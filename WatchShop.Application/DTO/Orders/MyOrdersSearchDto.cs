using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Orders
{
    public class MyOrdersSearchDto : PagedSearch
    {
        public int Id { get; set; }
    }
}
