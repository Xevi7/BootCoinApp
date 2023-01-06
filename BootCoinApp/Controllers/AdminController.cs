using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BootCoinApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        public AdminController(UserManager<AppUser> userManager, IUserRepository userRepository) 
        { 
            _userManager = userManager;
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Input()
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<AppUser> users = await _userRepository.GetAll();
            AppUser CurrentUser = await _userRepository.GetByIdAsync(id);
            var model = new IndexHomeViewModel
            {
                currentUser = CurrentUser,
                users = users,
                usersCount = users.Count(),
            };
            return View(model);
        }

        public IActionResult InputCoinPerUser(int totalCoins, String events, String activeness)
        {
            ViewBag.TotalCoins = totalCoins;
            ViewBag.Events = events;
            ViewBag.Activeness = activeness;
            return View("Result");
        }

        public IActionResult InputCoinPerGroup(string group, int totalCoins, String events, String activeness)
        {
            ViewBag.Group = group;
            ViewBag.TotalCoins = totalCoins;
            ViewBag.Events = events;
            ViewBag.Activeness = activeness;
            return View("Result");
        }
    }
}
