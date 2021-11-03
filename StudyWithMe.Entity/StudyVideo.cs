using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity.Abstract;

namespace StudyWithMe.Entity
{
    // IEntity'den türetilir. Bu StudyVideo class'ının Entity'den üretildiğini gösterir
    public class StudyVideo : IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string VideoName { get; set; }
        public int BroadcastingId { get; set; }
    }
}