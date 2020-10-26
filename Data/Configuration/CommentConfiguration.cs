using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.CommentId).UseIdentityColumn();
            builder.Property(x => x.CommentContent).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
