using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity.Abstract;

namespace StudyWithMe.Entity
{
    public class GroupVideoDetail : IEntity
    {
        public int GroupVideoId { get; set; }
        public string CreatedByUserId { get; set; }
        public string GroupVideoName { get; set; }
        public string HostUrl { get; set; }
        public string JoinUrl { get; set; }
        public string Description { get; set; }
        public byte[] VideoImage { get; set; }
        public int MaxUsersCount { get; set; }
        public int JoinedUserCount { get; set; }
        public IList<GroupVideoGenre> GroupVideoGenres {get; set;}
    }
}