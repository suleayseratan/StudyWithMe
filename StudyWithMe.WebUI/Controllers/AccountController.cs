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
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
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

            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                // Login sayfasına yönlendirilmeden önce bir generate tooken atanır


                // Eğer başarılı bir şekilde kayıt oluşursa Login sayfasına yönlendirilir.
                return RedirectToAction("Account","Login");
            }

            return View(model); // Eğer başarılı değilse bu sayfaya girer ve model geri döndürülür
        }
    }
}