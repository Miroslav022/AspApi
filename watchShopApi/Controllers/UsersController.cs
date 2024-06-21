using Castle.Core.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.DTO.Users;
using WatchShop.Application.DTO.UserUseCasesDto;
using WatchShop.Application.UseCases.Commands.Statuses;
using WatchShop.Application.UseCases.Commands.Users;
using WatchShop.Application.UseCases.Commands.UserUseCases;
using WatchShop.Application.UseCases.Queries.Products;
using WatchShop.Application.UseCases.Queries.Users;
using WatchShop.Implementation;
using watchShopApi.Core;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;
        private ISendEmail _emailSender;
        public UsersController(UseCaseHandler useCaseHandler, ISendEmail emailSender)
        {
            _useCaseHandler = useCaseHandler;
            _emailSender = emailSender;
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSingleUserQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, id));

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] SearchUserDto search, [FromServices] IGetUsersQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
        [HttpPost]
        public IActionResult Post([FromServices] IRegisterUserCommand command, RegisterUserDto dto)
        {
            _useCaseHandler.HandleCommand(command, dto);
            _emailSender.SendEmailAsync("jandric013@gmail.com", "test", "test");
            return StatusCode(201);
        }
        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteUserCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromServices] IEditUserCommand command, EditUserDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
        [Authorize]
        [HttpPut("editAccount")]
        public IActionResult EditUserAccount([FromServices] IEditMyAccount command, EditMyAccount data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }

        [HttpPut("access")]
        public IActionResult ModifyAccess(int id, [FromBody] UserUseCaseDto dto,
                                                  [FromServices] IAddUserUseCaseCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}
