using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity.Abstract;

namespace StudyWithMe.Entity
{
    public class Follower : IEntity
    {
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
    }
}