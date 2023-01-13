using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BootCoinApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository, UserManager<AppUser> userManager, ITransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<AppUser> users = await _userRepository.GetAllInternExceptIdAsync(id);
            AppUser CurrentUser = await _userRepository.GetByIdAsync(id);
            var model = new IndexHomeViewModel
            {
                currentUser = CurrentUser,
                users = users,
                usersCount = users.Count(),
            };
            if (User.IsInRole(UserRoles.user))
            {
                Transaction latestMission = await _transactionRepository.GetLatestTransactionByIdAsync(id);
                model.latestMission = latestMission;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}