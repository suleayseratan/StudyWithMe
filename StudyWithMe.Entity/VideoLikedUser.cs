using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity.Abstract;

namespace StudyWithMe.Entity
{
    public class VideoLikedUser : IEntity
    {
        public int VideoId { get; set; }
        public StudyVideo StudyVideo {get; set;}
        public int UserId { get; set; }

    }
}