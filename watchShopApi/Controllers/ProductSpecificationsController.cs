using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application.DTO.ProductSpecificationsDtos;
using WatchShop.Application.UseCases.Commands.ProductSpecificationsCommands;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public ProductSpecificationsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] ICreateProductSpecificationCommand command, [FromBody] AddProductSpecificationDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] IDeleteProductSpecification command, [FromBody] DeleteProductSpecificationDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
