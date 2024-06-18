using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Location : Entity
    {
        public int CityId { get; set; }
        public string Address { get; set; }
        public  virtual City City { get; set; }

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
