using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Orders;

namespace WatchShop.Application.UseCases.Commands.Orders
{
    public interface ICreateOrderCommand : ICommand<CreateOrderDto>
    {
    }
}
