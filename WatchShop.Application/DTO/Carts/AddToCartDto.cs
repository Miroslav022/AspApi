using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Carts
{
    public class AddToCartDto
    {
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int PriceId { get; set; }
    }
}
