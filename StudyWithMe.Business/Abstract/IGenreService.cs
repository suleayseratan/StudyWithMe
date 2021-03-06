using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity;

namespace StudyWithMe.Business.Abstract
{
    public interface IGenreService : IValidator<Genre>
    {
        List<Genre> GetAll();
    }
}