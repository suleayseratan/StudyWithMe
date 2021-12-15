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

        public List<GroupVideoDetail> GetGroupVideosByGenre(string name, int page, int pageSize)
        {
            var groupVideos = StudyWithMeContext
            .GroupVideoDetails.AsQueryable();

            if(!string.IsNullOrEmpty(name))
            {
                groupVideos = groupVideos.Include(i=>i.GroupVideoGenres)
                .ThenInclude(i=>i.Genre)
                .Where(i=>i.GroupVideoGenres.Any(a=>a.Genre.Name == name));
            }

            return groupVideos.Skip((page-1)*pageSize).ToList();
        }

        public List<GroupVideoDetail> GetSearchResults(string query, int page, int pageSize)
        {
            var groupVideos = StudyWithMeContext.GroupVideoDetails
            .Where(i=>i.GroupVideoName.ToLower().Contains(query.ToLower()) || i.Description.ToLower().Contains(query.ToLower())).AsQueryable();

            return groupVideos.ToList();
        }
    }
}