using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;
using Zamawianie_biletow.Models;

namespace Zamawianie_biletow.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login userLoginData/*, LoginName LoginName*/)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }

            // logika która loguje
            await _signInManager.PasswordSignInAsync(userLoginData.UserLogin, userLoginData.Password, false, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register userRegisterData)
        {
            if(!ModelState.IsValid) 
            {
                return View(userRegisterData);
            }

            // logika rejestrująca

            var newUser = new UserModel
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.UserLogin
            };
            
            await _userManager.CreateAsync(newUser, userRegisterData.Password);

            return RedirectToAction("Index", "Home");
        }
       
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
