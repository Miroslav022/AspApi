using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Users;
using WatchShop.Domain.Entities;

namespace WatchShop.Application.DTO.Carts
{
    public class CartDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; }
    }
}
