using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Business.Abstract;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.Entity;

namespace StudyWithMe.Business.Concrete
{
    public class GroupVideoDetailManager : IGroupVideoDetailService
    {
        public string ErrorMessage { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public GroupVideoDetailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Create(GroupVideoDetail entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.GroupVideoDetails.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public List<GroupVideoDetail> GetAll(int page,int pageSize)
        {
            var groupVideos = _unitOfWork.GroupVideoDetails.GetAll();
            return groupVideos.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public bool Validation(GroupVideoDetail entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.GroupVideoName))
            {
                ErrorMessage += "You must enter group name\n";
                isValid = false;
            }

            return isValid;
        }

        public List<GroupVideoDetail> GetGroupVideosByCategory(string name, int page, int pageSize)
        {
            return _unitOfWork.GroupVideoDetails.GetGroupVideosByGenre(name,page,pageSize);
        }

        public int GroupVideosCount()
        {
            return _unitOfWork.GroupVideoDetails.GetAll().Count();
        }

        public List<GroupVideoDetail> GetSearchResults(string query, int page, int pageSize)
        {
            var serachResult = _unitOfWork.GroupVideoDetails.GetSearchResults(query,page,pageSize);
            return serachResult.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }
    }
}