using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Carts;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Carts;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;
        private readonly IApplicationActor _actor;

        public CartItemsController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }

        [HttpDelete]
        public IActionResult Post([FromServices] IDeleteCartItemCommand command, [FromBody] DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
