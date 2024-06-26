﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Domain.Entities
{
    public class Category : NamedEntity
    {
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
