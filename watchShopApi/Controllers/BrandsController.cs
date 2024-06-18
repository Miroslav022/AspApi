using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Brands;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.CommonUseCase;
using WatchShop.Application.UseCases.Queries.Brands;
using WatchShop.DataAccess;
using WatchShop.Implementation;
using WatchShop.Implementation.UseCases.Commands.Brands;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private UseCaseHandler _handler;
        public BrandsController(UseCaseHandler handler, IApplicationActor actor)
        {

            _handler = handler;
            _actor = actor;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BrandSearch search, [FromServices] IGetBrandsQuery query)
            => Ok(_handler.HandleQuery(query, search));


        [HttpPost]
        public IActionResult Post([FromServices] ICreateBrandCommand command, [FromBody] NamedEntityDto dto)
        {
            try
            {
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteBrandCommand command, DeleteDto data)
        {
            _handler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
