using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.CommonUseCase;
using WatchShop.Application.UseCases.Commands.Statuses;
using WatchShop.Application.UseCases.Queries.Categories;
using WatchShop.Application.UseCases.Queries.Statuses;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public StatusesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearchDto search, [FromServices] IGetStatusesQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, search));

        [HttpPost]
        public IActionResult Post([FromServices] ICreateStatusCommand command, [FromBody] NamedEntityDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteStatusCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
