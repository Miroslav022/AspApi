using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class CartItem : Entity
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int PriceId { get; set; }

        public virtual Price ProductPrice { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
