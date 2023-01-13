using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository, UserManager<AppUser> userManager, ITransactionRepository transactionRepository, SignInManager<AppUser> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _transactionRepository = transactionRepository;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            if(!_signInManager.IsSignedIn(HttpContext.User))
            {
                return RedirectToAction("Login", "Account");
            }
            string id = _userManager.GetUserId(User);
            IEnumerable<AppUser> users;
            if (String.IsNullOrEmpty(search))
            {
                users = await _userRepository.GetAllInternExceptIdAsync(id);
            }
            else
            {
                users = await _userRepository.SearchInternExceptIdAsync(id, search);
                ViewData["SearchQuery"] = search;
            }
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