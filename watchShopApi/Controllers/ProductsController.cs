using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WatchShop.Application.DTO.Brands;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.Product;
using WatchShop.Application.UseCases.Commands.Brands;
using WatchShop.Application.UseCases.Commands.Products;
using WatchShop.Application.UseCases.Queries.Brands;
using WatchShop.Application.UseCases.Queries.Products;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public ProductsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IProductDetailsQuery query,int id)
        {
            return Ok(_useCaseHandler.HandleQuery(query, id));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IProductSearchQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] ICreateProductCommand command, [FromBody] CreateProductDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromServices] IEditProductCommand command, EditProductDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteProductCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
