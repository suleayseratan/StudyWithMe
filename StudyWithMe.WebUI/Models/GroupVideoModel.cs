using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity;

namespace StudyWithMe.WebUI.Models
{
    public class GroupVideoModel
    {
        public string GroupName { get; set; }
        public int GenreId { get; set; }
        public int MemberCount { get; set; }
        public string CreatedByUser { get; set; }
        public string Description { get; set; }
        public int MaxUsersCount { get; set; }
        public string VideoImage { get; set; }
        public int JoinedUserCount { get; set; }
        public IList<Genre> GroupGenre {get; set;}

    }
}