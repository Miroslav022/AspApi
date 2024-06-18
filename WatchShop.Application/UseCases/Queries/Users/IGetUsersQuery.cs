using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Application.DTO;
using WatchShop.Application.DTO.Users;

namespace WatchShop.Application.UseCases.Queries.Users
{
    public interface IGetUsersQuery : IQuery<PagedResponse<UserDto>, SearchUserDto>
    {
    }
}
