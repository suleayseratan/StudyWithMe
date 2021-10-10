using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWithMe.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IFollowerRepository Followers {get;}
        IGenreRepository Genres {get;}
        IGroupVideoDetailRepository GroupVideoDetails {get;}
        IGroupVideoGenreRepository GroupVideoGenres {get;}
        IStudyVideoRepository StudyVideos {get;}
        IVideoLikedUserRepository VideoLikedUsers {get;}
        void Save();
    }
}