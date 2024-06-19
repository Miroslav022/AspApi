using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.Categories;
using WatchShop.Application.UseCases.Commands.Specifications;
using WatchShop.Application.UseCases.Queries.Products;
using WatchShop.Application.UseCases.Queries.Specifications;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;
        public SpecificationsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearchDto search, [FromServices] IGetSpecificationsQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] ICreateSpecificationCommand command, NamedEntityDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }
        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteSpecificationCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
