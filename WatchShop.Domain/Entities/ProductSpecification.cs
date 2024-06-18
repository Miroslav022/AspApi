using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class ProductSpecification
    {
        public int SpecificationId { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }

        public virtual Specification Specification { get; set; }
        public virtual Product Product { get; set; }
    }
}
