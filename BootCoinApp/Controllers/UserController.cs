using BootCoinApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BootCoinApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Authorize(Roles = UserRoles.user)]
        public IActionResult Support()
        {
            return View();
        }
    }
}
