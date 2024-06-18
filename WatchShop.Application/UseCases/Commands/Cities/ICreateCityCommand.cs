using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.Cities;

namespace WatchShop.Application.UseCases.Commands.Cities
{
    public interface ICreateCityCommand : ICommand<CreateCityDto>
    {

    }
}
