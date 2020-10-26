using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class MusicConfigurtaion : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.HasKey(x => x.MusicId);
            builder.Property(x => x.MusicId).UseIdentityColumn();
            builder.Property(x => x.MusicName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.MusicDescription).HasMaxLength(500);
            builder.Property(x => x.MusicLink).IsRequired().HasMaxLength(500);
            builder.Property(x => x.TotalLikes).HasDefaultValue(0);
            builder.Property(x => x.TotalComments).HasDefaultValue(0);
        }
    }
}
