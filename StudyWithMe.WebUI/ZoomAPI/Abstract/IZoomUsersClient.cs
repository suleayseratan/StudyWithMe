using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.WebUI.Identity;

namespace StudyWithMe.WebUI.ZoomAPI.Abstract
{
    public interface IZoomUsersClient
    {
        ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30,int pageNumber = 1);
        User CreateUser(CreateUser createUser, string action);
        User GetUser(string usertId, LoginTypes? loginType = null);
        bool UpdateUser(string userId, UpdateUser user);
        bool CheckUser(string email);
        bool DeleteUser(string userId, string action = "disassociate", string transferEmail = null, bool transferMeeting = false, bool transferWebinar = false, bool transferRecording = false);
    }
}