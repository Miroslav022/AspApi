using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchShop.Application;
using WatchShop.Application.DTO.Common;
using WatchShop.Application.DTO.Recensions;
using WatchShop.Application.UseCases.Commands.Images;
using WatchShop.Application.UseCases.Commands.Recensions;
using WatchShop.Implementation;

namespace watchShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecensionsController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly UseCaseHandler _useCaseHandler;

        public RecensionsController(UseCaseHandler useCaseHandler, IApplicationActor actor)
        {
            _useCaseHandler = useCaseHandler;
            _actor = actor;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] ICreateRecensionCommand command, CreateRecensionDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteRecensionCommand command, DeleteDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }
    }
}
