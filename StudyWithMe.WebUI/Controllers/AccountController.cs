using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyWithMe.WebUI.EmailServices;
using StudyWithMe.WebUI.Extensions;
using StudyWithMe.WebUI.Identity;
using StudyWithMe.WebUI.Models;

namespace StudyWithMe.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken] // Controller seviyesinde bir token kontolü için kullanılır
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
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

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Please check your email address!");
                return View(model);
            }

            // isPersistent -> Cookie yaşam süresi
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "/");
            }

            ModelState.AddModelError("", "Wrong Password or Email");
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
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = token
                }); // Created url with token

                await _emailSender.SendEmailAsync(model.Email,"Email Activaiton",$"Please click the <a href='https://localhost:5001{url}'>link</a> for confirm your emial account.");

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

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Token",
                    Message = "Invalid Token!",
                    AlertType = "danger"
                });
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Account Confirm",
                        Message = "Your account confirmed.",
                        AlertType = "success"
                    });
                    return View();
                }
            }

            TempData.Put("message", new AlertMessage()
            {
                Title = "User",
                Message = "There is no such user!",
                AlertType = "danger"
            });
            return View();
        }

    }
}