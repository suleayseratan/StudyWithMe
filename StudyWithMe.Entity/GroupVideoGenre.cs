using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.Entity
{
    public class GroupVideoGenre
    {
        public int GroupId { get; set; }
        public GroupVideoDetail GroupVideoDetail { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}