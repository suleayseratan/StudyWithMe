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

        public List<GroupVideoDetail> GetAll()
        {
            return _unitOfWork.GroupVideoDetails.GetAll();
        }

        // public GroupVideoDetail GetGroupVideoDetail(string url)
        // {
        //     _unitOfWork.GroupVideoDetails.GetGroupVideos(url);
        // }
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


    }
}