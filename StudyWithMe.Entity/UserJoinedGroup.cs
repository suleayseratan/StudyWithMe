using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.Entity
{
    public class UserJoinedGroup
    {
        public int GroupId { get; set; }
        public GroupVideoDetail GroupVideoDetail { get; set; }
        public int UserId { get; set; }
    }
}