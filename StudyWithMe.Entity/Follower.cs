using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.Entity
{
    public class Follower
    {
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
    }
}