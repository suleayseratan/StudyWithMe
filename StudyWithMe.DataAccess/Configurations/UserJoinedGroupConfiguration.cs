using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyWithMe.Entity;

namespace StudyWithMe.DataAccess.Configurations
{
    public class UserJoinedGroupConfiguration : IEntityTypeConfiguration<UserJoinedGroup>
    {
        public void Configure(EntityTypeBuilder<UserJoinedGroup> builder)
        {
            builder.HasKey(ug => new {ug.GroupId, ug.UserId});
        }
    }
}