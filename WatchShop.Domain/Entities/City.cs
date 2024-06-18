using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class City : NamedEntity
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Location> Locations { get; set; } = new HashSet<Location>();
    }
}
