using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Carts;

namespace WatchShop.Application.UseCases.Commands.Carts
{
    public interface IAddToCartCommand : ICommand<AddToCartDto>
    {
    }
}
