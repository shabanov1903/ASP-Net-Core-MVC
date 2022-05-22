using MailManager.WebApi.Identity.Entities;
using MailManager.WebApi.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MailManager.WebApi.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(
            UserManager<User> User,
            SignInManager<User> SignInManager,
            ILogger<AccountController> Logger)
        {
            _UserManager = User;
            _SignInManager = SignInManager;
            _Logger = Logger;
        }

        public UserManager<User> _UserManager { get; }
        public SignInManager<User> _SignInManager { get; }
        public ILogger<AccountController> _Logger { get; }

        #region Register
        public IActionResult Register()
        {
            return View(new RegisterUserDto());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto Model)
        {
            if (!ModelState.IsValid)
                return View(Model);

            var user = new User
            {
                UserName = Model.UserName,
            };

            var result = await _UserManager.CreateAsync(user, Model.Password);
            if (result.Succeeded)
            {
                await _SignInManager.SignInAsync(user, false);
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(Model);
        }
        #endregion

        #region Login
        public IActionResult Login(string? ReturnUrl = null)
        {
            return View(new LoginDto { ReturnUrl = ReturnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto Model)
        {
            if (!ModelState.IsValid)
                return View(Model);

            var result = await _SignInManager.PasswordSignInAsync(
                Model.UserName,
                Model.Password,
                Model.RememberMe,
                true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Mail");
            }

            ModelState.AddModelError("", "Неверное имя пользователя или пароль");

            return View(Model);
        }
        #endregion

        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
