using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Configurations
{
    public class GroupVideoGenreConfiguration : IEntityTypeConfiguration<GroupVideoGenre>
    {
        public void Configure(EntityTypeBuilder<GroupVideoGenre> builder)
        {
            builder.HasKey(v=> new {v.GenreId, v.GroupId});
            
            builder
            .HasOne<GroupVideoDetail>(vg => vg.GroupVideoDetail)
            .WithMany(s => s.GroupVideoGenres)
            .HasForeignKey(vg => vg.GroupId);

            builder.HasOne<Genre>(g => g.Genre)
            .WithMany(g => g.GroupVideoGenres)
            .HasForeignKey(vg => vg.GenreId);
        }
    }
}