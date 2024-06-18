using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Carts;
using WatchShop.Application.DTO.Orders;
using WatchShop.Application.UseCases.Commands.Carts;
using WatchShop.Application.UseCases.Queries.Carts;
using WatchShop.Application.UseCases.Queries.Orders;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;
        private readonly IApplicationActor _actor;
        public CartController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CartSearchDto search, [FromServices] IGetCartsQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, search));

        [HttpPost]
        public IActionResult Post([FromServices] IAddToCartCommand command, [FromBody] AddToCartDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }
    }
}
