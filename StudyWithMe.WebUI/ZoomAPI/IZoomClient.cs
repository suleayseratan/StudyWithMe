using System;
using System.Collections.Generic;

namespace StudyWithMe.WebUI.ZoomAPI
{
    public interface IZoomClient
    {
        Dictionary<string, string> CreateZoomGroup(string email, string groupName, DateTime startTime);
        string CreateToken();
    }
}