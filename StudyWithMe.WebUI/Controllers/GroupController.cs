using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                DateTime startTime = DateTime.Now;
                var meetingInformations = CreateZoomGroup(model.GroupName,startTime);
                var group = new GroupVideoDetail()
                {
                    GroupVideoName = model.GroupName,
                    CreatedByUserId = userId,
                    HostUrl = meetingInformations["host"],
                    JoinUrl = meetingInformations["join"],
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

        private Dictionary<string,string> CreateZoomGroup(string groupName, DateTime startTime)
        {
            Dictionary<string,string> informations = new Dictionary<string, string>();
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var apiSecret = "04a7vdOpsLmEc7LktdbEYHSPDW58GywcznuW";
            byte[] symmetricKey = Encoding.ASCII.GetBytes(apiSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "F_TrcEjzRgWvv-NCsVcJvg",
                Expires = now.AddSeconds(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var client = new RestClient("https://api.zoom.us/v2/users/yy8799990@gmail.com/meetings");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { topic = groupName, duration = "10", start_time = startTime, type = "2" });
            request.AddHeader("authorization", String.Format("Bearer {0}", tokenString));

            IRestResponse restResponse = client.Execute(request);
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            var jObject = JObject.Parse(restResponse.Content);
            var host = (string)jObject["start_url"];
            var join = (string)jObject["join_url"];
            var code = Convert.ToString(numericStatusCode);
            informations.Add("host",host);
            informations.Add("join",join);
            informations.Add("code",code);
            return informations;
        }
    }
}