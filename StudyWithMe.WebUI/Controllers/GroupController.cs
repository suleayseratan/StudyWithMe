using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyWithMe.Business.Abstract;
using StudyWithMe.Entity;
using StudyWithMe.WebUI.Identity;
using StudyWithMe.WebUI.Models;

namespace StudyWithMe.WebUI.Controllers
{
    public class GroupController : Controller
    {
        private UserManager<User> _userManager;
        private IGenreService _genreService;
        public GroupController(UserManager<User> userManager, IGenreService genreService)
        {
            this._userManager = userManager;
            this._genreService = genreService;
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
            // var group = new GroupVideoDetail()
            // {
            //     GroupVideoId = model.
            // };
            return View();
        }
    }
}