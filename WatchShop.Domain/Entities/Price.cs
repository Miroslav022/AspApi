using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Price : Entity
    {
        public decimal Amount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();

    }
}
