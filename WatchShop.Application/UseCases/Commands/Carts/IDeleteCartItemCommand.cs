using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Common;

namespace WatchShop.Application.UseCases.Commands.Carts
{
    public interface IDeleteCartItemCommand : ICommand<DeleteDto>
    {
    }
}
