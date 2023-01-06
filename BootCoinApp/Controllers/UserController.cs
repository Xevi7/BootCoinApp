using Microsoft.AspNetCore.Mvc;

namespace BootCoinApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Support()
        {
            return View();
        }
    }
}
