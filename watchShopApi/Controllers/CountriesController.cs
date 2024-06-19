using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Countries;
using WatchShop.Application.UseCases.Commands.Statuses;
using WatchShop.Application.UseCases.Queries.Categories;
using WatchShop.Application.UseCases.Queries.Countries;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;
        private readonly IApplicationActor _actor;
        public CountriesController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }
        [HttpGet]

        public IActionResult Get([FromQuery] KeywordSearchDto search, [FromServices] IGetCountryQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] ICreateCountryCommand command, [FromBody] NamedEntityDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }
        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteCountryCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
