using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Status : NamedEntity
    {
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
