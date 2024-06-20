using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Configurations
{
    //internal class MessageConfiguration : EntityConfiguration<Message>
    //{
    //    protected override void ConfigureEntity(EntityTypeBuilder<Message> builder)
    //    {
    //        //throw new NotImplementedException();
    //    }
    //}

    internal class PrivateMessageConfiguration : EntityConfiguration<PrivateMessage>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<PrivateMessage> builder)
        {
            //throw new NotImplementedException();
        }
    }

    internal class GroupChatMessageConfiguration : EntityConfiguration<GroupChatMessage>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GroupChatMessage> builder)
        {
            //throw new NotImplementedException();
        }
    }
}
