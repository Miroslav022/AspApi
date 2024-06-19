using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Product;

namespace WatchShop.Application.UseCases.Commands.Products
{
    public interface IEditProductCommand : ICommand<EditProductDto>
    {
    }
}
