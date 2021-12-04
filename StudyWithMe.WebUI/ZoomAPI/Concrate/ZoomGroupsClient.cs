using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.WebUI.ZoomAPI.Concrate
{
    public class ZoomGroupsClient
    {
        const string deleteGroup = "groups/{groupId}";
        const string deleteGroupMember = "groups/{groupId}/members/{memberId}";

        const string getListGroup = "groups";
        const string getGroup = "groups/{groupId}";
        const string getGroupMember= "groups/{groupId}/members";

        const string patchGroup= "groups/{groupId}";

        const string postGroup = "groups";
        const string postGroupMembers = "groups/{groupId}/members";

        ZoomClientOptions Options {get; set;}
        RestClient WebClient {get; set;}
        
        internal ZoomGroupsClient(ZoomClientOptions options, RestClient webClient)
        {
            Options = options;
            WebClient = webClient;
        }

        public ListGroups GetGroups()
        {
            var request = BuildRequestAuthorizations
        }
    }
}