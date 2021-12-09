using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Concrete.EfCore
{
    public class EfCoreGroupVideoDetailRepository : EfCoreGenericRepository<GroupVideoDetail>, IGroupVideoDetailRepository
    {
        public EfCoreGroupVideoDetailRepository(DbContext context) : base(context)
        {
            
        }

        private StudyWithMeContext StudyWithMeContext
        {
            get {return _context as StudyWithMeContext; }
        }

        public GroupVideoDetail GetGroupVideoDetail(string url)
        {
            return StudyWithMeContext.GroupVideoDetails
            .Where(i=>i.Url == url)
            .Include(i=>i.GroupVideoGenres)
            .ThenInclude(i=>i.Genre)
            .FirstOrDefault();
        }
    }
}