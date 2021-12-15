using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity;

namespace StudyWithMe.Business.Abstract
{
    public interface IGroupVideoDetailService : IValidator<GroupVideoDetail>
    {
        bool Create(GroupVideoDetail entity);
        // GroupVideoDetail GetGroupVideoDetail(string url);
        List<GroupVideoDetail> GetAll(int page,int pageSize);
        List<GroupVideoDetail> GetGroupVideosByCategory(string name, int page, int pageSize);
        int GroupVideosCount();
        List<GroupVideoDetail> GetSearchResults(string query, int page, int pageSize);
         
    }
}