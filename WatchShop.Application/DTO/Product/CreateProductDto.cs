using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.ProductSpecificationsDtos;

namespace WatchShop.Application.DTO.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public IEnumerable<ProductSpecificationDto>? ProductSpecifications { get; set; }

        public decimal Price { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
