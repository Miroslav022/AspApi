using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Orders
{
    public class OrderSearchDto : PagedSearch
    {
        public string? Username { get; set; }
        public string? Status { get; set; }
    }
}
