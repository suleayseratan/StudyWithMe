using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudyWithMe.WebUI.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}