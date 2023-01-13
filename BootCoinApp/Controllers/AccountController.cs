using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Humanizer.In;

namespace BootCoinApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGroupRepository _groupRepository;
        private readonly IPositionRepository _positionRepository;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInmanager, IGroupRepository groupRepository, IPositionRepository positionRepository)
        {
            _signInManager = signInmanager;
            _userManager = userManager;
            _groupRepository = groupRepository;
            _positionRepository = positionRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid) { return View(loginViewModel); }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            
            if(user != null) 
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "Invalid login attempt";
                    return View(loginViewModel);
                }
                TempData["Error"] = "Your Password is either not registered or incorrect";
                return View(loginViewModel);
            }

            TempData["Error"] = "Your Email is either not registered or incorrect";
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            IEnumerable<Group> groupList = await _groupRepository.GetAll();
            IEnumerable<Position> positionList = await _positionRepository.GetAll();
            var response = new RegisterViewModel
            { 
                groupList = groupList,
                positionList = positionList,
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) { return View(registerViewModel); }

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This email adddress is already in use";
                return View(registerViewModel);
            }

            user = await _userManager.FindByNameAsync(registerViewModel.Name);
            if (user != null)
            {
                TempData["Error"] = "This username is already in use";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                UserName = registerViewModel.Name,
                Email = registerViewModel.Email,
                GroupId = registerViewModel.GroupId,
                PositionId = registerViewModel.PositionId,
            };
            var response = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (response.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.user);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
