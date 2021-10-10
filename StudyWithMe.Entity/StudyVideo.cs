using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.Entity
{
    public class StudyVideo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string VideoName { get; set; }
        public int BroadcastingId { get; set; }
    }
}