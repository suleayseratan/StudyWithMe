using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Configurations
{
    public class GroupVideoDetailConfiguration : IEntityTypeConfiguration<GroupVideoDetail>
    {
        public void Configure(EntityTypeBuilder<GroupVideoDetail> builder)
        {
            builder.HasKey(v=>v.GroupVideoId);
        }
    }
}