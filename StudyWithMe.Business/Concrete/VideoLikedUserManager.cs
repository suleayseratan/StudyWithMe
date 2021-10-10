using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.Business.Concrete
{
    public class VideoLikedUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public VideoLikedUserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}