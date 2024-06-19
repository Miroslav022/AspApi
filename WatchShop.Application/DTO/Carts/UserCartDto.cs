using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Application.DTO.Carts
{
    public class UserCartDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CartItemDto> Products { get; set; }
    }
}
