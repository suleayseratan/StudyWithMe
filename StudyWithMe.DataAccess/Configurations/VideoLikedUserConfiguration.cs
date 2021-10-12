using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Configurations
{
    public class VideoLikedUserConfiguration : IEntityTypeConfiguration<VideoLikedUser>
    {
        public void Configure(EntityTypeBuilder<VideoLikedUser> builder)
        {
            builder.HasKey(v=> new {v.VideoId, v.UserId});
        }
    }
}