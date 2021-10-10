using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.Business.Concrete
{
    public class FollowerManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public FollowerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}