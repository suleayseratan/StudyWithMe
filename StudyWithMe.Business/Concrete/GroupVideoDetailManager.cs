using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.Business.Concrete
{
    public class GroupVideoDetailManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupVideoDetailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}