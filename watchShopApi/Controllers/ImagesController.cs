using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.UseCases.Commands.Cities;
using WatchShop.Application.UseCases.Commands.Images;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public ImagesController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteImageCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
