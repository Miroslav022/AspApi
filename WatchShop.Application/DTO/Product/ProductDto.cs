using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.Application.DTO.Recensions;
using WatchShop.Domain.Entities;

namespace WatchShop.Application.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Brand { get; set; }
        public string Category { get; set; }
        public ICollection<ProductImageDto> Images { get; set; }
        public ICollection<ProductSpecificationSearchDto> ProductSpecifications { get; set; }
        public ICollection<RecensionDto> Recensions { get; set; }
    }
}
