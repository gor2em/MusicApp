using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.UserDetailId);
            builder.Property(x => x.UserDetailId).UseIdentityColumn();
            builder.Property(x => x.TotalLikes).HasDefaultValue(0);
            builder.Property(x => x.TotalComments).HasDefaultValue(0);
            builder.Property(x => x.TotalScore).HasDefaultValue(0);
            builder.Property(x => x.RoleId).HasDefaultValue(1);
        }
    }
}
