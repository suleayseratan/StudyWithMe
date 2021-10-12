using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.Entity
{
    public class VideoLikedUser
    {
        public int VideoId { get; set; }
        public StudyVideo StudyVideo {get; set;}
        public int UserId { get; set; }

    }
}