using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Users;

namespace WatchShop.Application.DTO.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }
    }
}
