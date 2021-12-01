using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyWithMe.Business.Abstract;
using StudyWithMe.Entity;
using StudyWithMe.WebUI.Extensions;
using StudyWithMe.WebUI.Identity;
using StudyWithMe.WebUI.Models;

namespace StudyWithMe.WebUI.Controllers
{
    public class GroupController : Controller
    {
        private UserManager<User> _userManager;
        private IGenreService _genreService;
        private IGroupVideoDetailService _groupVideoDetailService;
        public GroupController(UserManager<User> userManager, IGenreService genreService, IGroupVideoDetailService groupVideoDetailService)
        {
            this._userManager = userManager;
            this._genreService = genreService;
            this._groupVideoDetailService = groupVideoDetailService;
        }
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            ViewBag.Genres = _genreService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult CreateGroup(GroupVideoModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                var group = new GroupVideoDetail()
                {
                    GroupVideoName = model.GroupName,
                    CreatedByUserId = userId,
                    HostUrl = "localhost/",
                    JoinUrl = "",
                    Description = model.Description,
                    VideoImage = 1,
                    JoinedUserCount = 0,
                    MaxUsersCount = model.MaxUsersCount,
                };
                if (_groupVideoDetailService.Create(group))
                {
                    TempData.Put("message", new AlertMessage
                    {
                        Title = "Added Group",
                        Message = "Group Added successfully",
                        AlertType = "success"
                    });
                    return Redirect("~/");
                }
                TempData.Put("message", new AlertMessage
                {
                    Title = "Added Group",
                    Message = "Group Added successfully",
                    AlertType = "success"
                });
                return Redirect("~/");

            }

            return Redirect("~/");
        }
    }
}