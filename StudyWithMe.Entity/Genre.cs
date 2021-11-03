using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity.Abstract;

namespace StudyWithMe.Entity
{
    public class Genre : IEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public IList<GroupVideoGenre> GroupVideoGenres {get; set;}

    }
}