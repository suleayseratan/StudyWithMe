using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Abstract
{
    public interface IGroupVideoDetailRepository : IRepository<GroupVideoDetail>
    {
        GroupVideoDetail GetGroupVideoDetail(string url);
    
        List<GroupVideoDetail> GetGroupVideosByGenre(string name, int page, int pageSize);
        
    }
}