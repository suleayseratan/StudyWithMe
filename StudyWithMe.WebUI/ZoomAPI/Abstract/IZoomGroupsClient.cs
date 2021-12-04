using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.WebUI.ZoomAPI.Abstract
{
    public interface IZoomGroupsClient
    {
        ListGroups GetGroups();
        Group CreateGroup(CreateGoup createGoup);
        Group GetGroup(string groupId);
        bool UpdateGroup(string groupId, UpdateGroup group);
        bool DeleteGroup(string groupId);
        ListMembers GetGroupMembers(string groupId, int pageSize = 30; int pageNumber = 1);
        bool AddGroupMembers(string groupId, List<CreateMember> createMembers);
        bool DeleteGroupMembers(string groupId, string memberId);
    }
}