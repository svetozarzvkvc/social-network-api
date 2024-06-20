using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Configurations
{
    internal class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.HasIndex(x => x.Title);

            builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(x => x.PostMedias).WithOne(x => x.Post).HasForeignKey(x => x.PostId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //throw new NotImplementedException();

            builder.HasMany(x => x.Reactions).WithOne(x => x.Post).HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
