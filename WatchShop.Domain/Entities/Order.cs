using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public decimal Total { get; set; }
        public int StatusId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductOrder> Products { get; set; } = new HashSet<ProductOrder>();
    }
}
