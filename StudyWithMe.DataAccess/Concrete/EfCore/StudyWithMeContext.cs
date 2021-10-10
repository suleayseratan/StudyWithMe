using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Concrete.EfCore
{
    public class StudyWithMeContext : DbContext
    {
        public StudyWithMeContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Follower> Followers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GroupVideoDetail> GroupVideoDetails { get; set; }
        public DbSet<GroupVideoGenre> GroupVideoGenres { get; set; }
        public DbSet<StudyVideo> StudyVideos { get; set; }
        public DbSet<VideoLikedUser> VideoLikedUsers { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfiguration(new FollowerConfiguration())
        // }
    }
}