using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using StudyWithMe.WebUI.Extensions;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace StudyWithMe.WebUI.ZoomAPI
{
    public class ZoomClient : IZoomClient
    {
        private string _apiSecret;
        private string _baseUrl;
        public ZoomClient(string apiSecret, string baseUrl)
        {
            this._apiSecret = apiSecret;
            this._baseUrl = baseUrl;
        }

        public Dictionary<string, string> CreateZoomGroup(string email, string groupName, DateTime startTime)
        {
            var tokenString = CreateToken();
            Dictionary<string, string> informations = new Dictionary<string, string>();
            var client = new RestClient(_baseUrl + $"users/{email}/meetings");
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
            informations.Add("host", host);
            informations.Add("join", join);
            informations.Add("code", code);
            return informations;
        }

        public string CreateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            byte[] symmetricKey = Encoding.ASCII.GetBytes(this._apiSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "F_TrcEjzRgWvv-NCsVcJvg",
                Expires = now.AddSeconds(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }

}