using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.WebUI.ZoomAPI.Abstract
{
    public interface IZoomClient
    {
        IZoomGroupsClient Groups {get;}
        IZoomMeetingsClient Meetings{get;}
        IZoomUsersClient Users {get;}
        IZoomWebhookClient Webhooks {get;}

    }
}