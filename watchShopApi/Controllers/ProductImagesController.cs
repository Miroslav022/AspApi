using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application.DTO.Images;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.UseCases.Commands.ProductImages;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public ProductImagesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] EditProductImage data, [FromServices] IAddProductImagesCommand command)
        {
            _handler.HandleCommand(command, data);
            return StatusCode(201);
        }
    }
}
