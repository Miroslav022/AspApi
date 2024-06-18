using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class ProductOrder : Entity
    {
        public int PriceId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Price Price{ get; set; }
    }
}
