using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Core;

namespace SocialNetwork.API.Extensions
{
    public static class ControllerExtensions
    {

        public static IActionResult InternalServerError(this ControllerBase controller, object o)
        {
            return controller.StatusCode(500, o);
        }

    }
}
