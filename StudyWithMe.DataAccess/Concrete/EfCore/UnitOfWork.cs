using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.DataAccess.Abstract;

namespace StudyWithMe.DataAccess.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyWithMeContext _context;
        public UnitOfWork(StudyWithMeContext context)
        {
            _context = context;
        }
        private EfCoreFollowerRepository _followerRepository;
        private EfCoreGenreRepository _genreRepository;
        private EfCoreGroupVideoDetailRepository _groupVideoDetailRepository;
        private EfCoreGroupVideoGenreRepository _groupVideoGenreRepository;
        private EfCoreStudyVideoRepository _studyVideoRepository;
        private EfCoreVideoLikedUserRepository _videoLikedUserRepository;
        public IFollowerRepository Followers => 
        _followerRepository = _followerRepository ?? new EfCoreFollowerRepository(_context);

        public IGenreRepository Genres =>
         _genreRepository = _genreRepository ?? new EfCoreGenreRepository(_context);

        public IGroupVideoDetailRepository GroupVideoDetails => _groupVideoDetailRepository = _groupVideoDetailRepository ?? new EfCoreGroupVideoDetailRepository(_context);

        public IGroupVideoGenreRepository GroupVideoGenres => _groupVideoGenreRepository = _groupVideoGenreRepository ?? new EfCoreGroupVideoGenreRepository(_context);

        public IStudyVideoRepository StudyVideos => _studyVideoRepository = _studyVideoRepository ?? new EfCoreStudyVideoRepository(_context);

        public IVideoLikedUserRepository VideoLikedUsers => _videoLikedUserRepository = _videoLikedUserRepository ?? new EfCoreVideoLikedUserRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}