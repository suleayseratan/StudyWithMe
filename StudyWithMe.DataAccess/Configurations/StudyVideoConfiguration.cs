using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Configurations
{
    public class StudyVideoConfiguration : IEntityTypeConfiguration<StudyVideo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StudyVideo> builder)
        {
            builder.HasKey(v=>v.Id);
        }
    }
}