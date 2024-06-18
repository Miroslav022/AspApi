using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Recension : Entity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
