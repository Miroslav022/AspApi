using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.Orders;
using WatchShop.Application.UseCases.Commands.Orders;
using WatchShop.Application.UseCases.Queries.Orders;
using WatchShop.Application.UseCases.Queries.Statuses;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;
        private readonly IApplicationActor _actor;

        public OrdersController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearchDto search, [FromServices] IGetOrdersQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, search));

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto data, [FromServices] ICreateOrderCommand command)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }
    }
}
