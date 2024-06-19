using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO.UserUseCasesDto;

namespace WatchShop.Application.UseCases.Commands.UserUseCases
{
    public interface IAddUserUseCaseCommand : ICommand<UserUseCaseDto>
    {
    }
}
