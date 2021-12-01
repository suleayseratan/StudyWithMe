using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Business.Abstract;
using StudyWithMe.DataAccess.Abstract;
using StudyWithMe.Entity;

namespace StudyWithMe.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<Genre> GetAll()
        {
            return _unitOfWork.Genres.GetAll();
        }

        public bool Validation(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}