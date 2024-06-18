using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Country : NamedEntity
    {
        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
