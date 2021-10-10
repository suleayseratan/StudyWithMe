using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.Business.Concrete
{
    public class GenreManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}