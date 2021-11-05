using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyWithMe.WebUI.Identity;
using StudyWithMe.WebUI.Models;

namespace StudyWithMe.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken] // Controller seviyesinde bir token kontolü için kullanılır
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel(){
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email not found");
                return View(model);
            }

            // isPersistent -> Cookie yaşam süresi
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"/");
            }
            
            ModelState.AddModelError("","Wrong Password or Email");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Form ile gönderilen token bilgisinin geri gönderilip gönderilrmediğini kontrol eder (cross site arakları için önemlidir.)
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Login sayfasına yönlendirilmeden önce bir generate tooken atanır


                // Eğer başarılı bir şekilde kayıt oluşursa Login sayfasına yönlendirilir.
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "An error occurred please try again later.");

            return View(model); // Eğer başarılı değilse bu sayfaya girer ve model geri döndürülür
        }

        public async Task<IActionResult> Logout(LoginModel model)
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/"); 
        }
    }
}