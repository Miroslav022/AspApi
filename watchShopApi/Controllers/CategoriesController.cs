using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WatchShop.Application;
using WatchShop.Application.DTO.Brands;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.Categories;
using WatchShop.Application.UseCases.Commands.CommonUseCase;
using WatchShop.Application.UseCases.Queries.Brands;
using WatchShop.Application.UseCases.Queries.Categories;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;
        private readonly IApplicationActor _actor;
        public CategoriesController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearchDto search, [FromServices] ICategorySearchQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));

        [HttpPost]
        public IActionResult Post([FromServices] ICreateCategoryCommand command, NamedEntityDto dto)
        {
            _useCaseHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteCategoryCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
