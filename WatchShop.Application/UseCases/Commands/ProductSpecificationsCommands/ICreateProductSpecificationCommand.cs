using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.ProductSpecificationsDtos;

namespace WatchShop.Application.UseCases.Commands.ProductSpecificationsCommands
{
    public interface ICreateProductSpecificationCommand : ICommand<AddProductSpecificationDto>
    {
    }
}
