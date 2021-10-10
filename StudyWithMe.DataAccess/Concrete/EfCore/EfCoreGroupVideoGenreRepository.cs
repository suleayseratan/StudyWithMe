using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Concrete.EfCore
{
    public class EfCoreGroupVideoGenreRepository : EfCoreGenericRepository<GroupVideoGenre>, IGroupVideoGenreRepository
    {
        public EfCoreGroupVideoGenreRepository(DbContext context) : base(context)
        {
            
        }

        private StudyWithMeContext StudyWithMeContext
        {
            get{ return _context as StudyWithMeContext; }
        }
    }
}