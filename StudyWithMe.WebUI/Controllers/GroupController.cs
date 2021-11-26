using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyWithMe.WebUI.Models;

namespace StudyWithMe.WebUI.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGroup(GroupVideoModel model)
        {
            return View();
        }
    }
}