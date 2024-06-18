using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class ProductImage
    {
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public bool IsBackground { get; set; }

        public virtual Image Image { get; set; } 
        public virtual Product Product { get; set; }
    }
}
