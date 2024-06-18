using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Specification : NamedEntity
    {
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; } = new HashSet<ProductSpecification>();
    }
}
