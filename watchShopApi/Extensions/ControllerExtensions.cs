using Microsoft.AspNetCore.Mvc;

namespace watchShopApi.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult InternalServerError(this ControllerBase controller, object o)
        {
            return controller.StatusCode(500, o);
        }
    }
}
