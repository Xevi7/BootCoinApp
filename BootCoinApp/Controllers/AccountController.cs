using BootCoinApp.Data;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BootCoinApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInmanager, ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInmanager;
            _userManager = userManager;
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
            if(user == null) { user = await _userManager.FindByNameAsync(loginViewModel.Email); }
            
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
                    TempData["Error"] = "Invalid Login Attempt";
                    return View(loginViewModel);
                }
            }
            TempData["Error"] = "Invalid Login Attempt";
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
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
            };
            var response = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (response.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.user);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
