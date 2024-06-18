using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Product
{
    public class ProductSearch : PagedSearch
    {
        public string? Keyword { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
    }
}
