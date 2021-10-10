using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.Entity
{
    public class GroupVideoDetail
    {
        public int GroupVideoId { get; set; }
        public int BroadcastingId { get; set; }
        public string Description { get; set; }
        public int MaxUsersCount { get; set; }
    }
}