using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.Business.Concrete
{
    public class GroupVideoGenreManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupVideoGenreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}