using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Image : Entity
    {
        public string path { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
