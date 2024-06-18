using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; } = new HashSet<ProductImage>();
        public virtual ICollection<Price> Prices { get; set; } = new HashSet<Price>();
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; } = new HashSet<ProductSpecification>();
        public virtual ICollection<Recension> Recensions { get; set; } = new HashSet<Recension>();
    }
}
