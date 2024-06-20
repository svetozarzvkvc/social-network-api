using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.DataAccess.Configurations
{
    internal class ReactionConfiguration : NamedEntityConfiguration<Reaction>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasOne(x=>x.Icon).WithMany().HasForeignKey(x=>x.FileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
