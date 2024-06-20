using Microsoft.Data.SqlClient;
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
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            //builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            //builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            
            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.LastName).HasMaxLength(30);

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);

            builder.HasIndex(x => new { x.FirstName, x.LastName, x.UserName, x.Email })
                .IncludeProperties(x=> x.BirthDate);

            builder.HasOne(x=>x.Image).WithMany().HasForeignKey(x=>x.ImageId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.Role).WithMany(x=>x.Users).HasForeignKey(x=>x.RoleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupChatUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Restrict); //Y

            builder.HasMany(x => x.ReceivedPrivateMessages).WithOne(x => x.Receiver).HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); //Y

            builder.HasMany(x => x.SentPrivateMessages).WithOne(x => x.Sender).HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict); //Y

            builder.HasMany(x => x.SentRequests).WithOne(x => x.Sender).HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict); //Y

            builder.HasMany(x => x.ReceivedRequests).WithOne(x => x.Receiver).HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); //Y


            builder.HasMany(x => x.PostReactions).WithOne(x => x.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CommentReactions).WithOne(x => x.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.SentGroupChatMessages).WithOne(x => x.Sender).HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GroupChatMessageReaction).WithOne(x => x.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PrivateMessageReactions).WithOne(x => x.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
