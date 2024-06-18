using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.ProductSpecificationsDtos
{
    public class AddProductSpecificationDto
    {
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public string Value { get; set; }
    }
}
