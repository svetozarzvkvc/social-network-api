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
    internal class GroupConfiguration : NamedEntityConfiguration<GroupChat>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GroupChat> builder)
        {
            //throw new NotImplementedException();
            builder.HasMany(x => x.GroupChatUsers).WithOne(x => x.GroupChat).HasForeignKey(x => x.GroupChatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupChatMessages).WithOne(x => x.GroupChat).HasForeignKey(x => x.GroupChatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
