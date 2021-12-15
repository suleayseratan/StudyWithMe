using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RestSharp;
using StudyWithMe.Business.Abstract;
using StudyWithMe.Entity;
using StudyWithMe.WebUI.Extensions;
using StudyWithMe.WebUI.Identity;
using StudyWithMe.WebUI.Models;
using StudyWithMe.WebUI.ViewModels;
using StudyWithMe.WebUI.ZoomAPI;

namespace StudyWithMe.WebUI.Controllers
{
    public class GroupController : Controller
    {
        private UserManager<User> _userManager;
        private IGenreService _genreService;
        private IGroupVideoDetailService _groupVideoDetailService;
        private IZoomClient _zoomClient;
        public GroupController(UserManager<User> userManager, IGenreService genreService, IGroupVideoDetailService groupVideoDetailService, IZoomClient zoomClient)
        {
            this._userManager = userManager;
            this._genreService = genreService;
            this._groupVideoDetailService = groupVideoDetailService;
            this._zoomClient = zoomClient;
        }
        public IActionResult List(string query, int page = 1)
        {
            int pageSize = 9;
            var groupViewModel = new GroupVideoViewModel()
            {
                GroupVideos = query == null?_groupVideoDetailService.GetAll(page,pageSize):_groupVideoDetailService.GetSearchResults(query,page, pageSize),
                PageInfo = new PageInfo(query == null?_groupVideoDetailService.GroupVideosCount():_groupVideoDetailService.GetSearchResults(query,page, pageSize).Count(), page)
            };
            return View(groupViewModel);
        }
        
        [Authorize(Roles = "Broadcaster")]
        [HttpGet]
        public IActionResult CreateGroup()
        {
            ViewBag.Genres = _genreService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupVideoModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userId);
                DateTime startTime = DateTime.Now;
                var meetingInformations = _zoomClient.CreateZoomGroup(user.Email, model.GroupName, startTime);
        
                var group = new GroupVideoDetail()
                {
                    GroupVideoName = model.GroupName,
                    CreatedByUserId = userId,
                    HostUrl = meetingInformations["host"],
                    JoinUrl = meetingInformations["join"],
                    Description = model.Description,
                    JoinedUserCount = 0,
                    MaxUsersCount = model.MaxUsersCount,
                };

                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        group.VideoImage = dataStream.ToArray();
                    }
                }

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