using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Cities;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Cities;
using WatchShop.Application.UseCases.Commands.Countries;
using WatchShop.Application.UseCases.Queries.Cities;
using WatchShop.Application.UseCases.Queries.Statuses;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;
        private readonly IApplicationActor _actor;
        public CitiesController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearchDto search, [FromServices] IGetCitiesQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, search));

        [HttpPost]
        public IActionResult Post([FromBody] CreateCityDto data, [FromServices] ICreateCityCommand command)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
            
        }

        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteCityCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
