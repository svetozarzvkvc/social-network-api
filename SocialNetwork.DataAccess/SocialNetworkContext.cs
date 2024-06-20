using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialNetwork.Domain;
using System;
using System.Collections.Generic;

namespace SocialNetwork.DataAccess
{
    public class SocialNetworkContext : DbContext
    {
        private readonly string _socialcontext;
        public SocialNetworkContext(string socialcontext)
        {
            _socialcontext = socialcontext;
        }
        public SocialNetworkContext()
        {
            _socialcontext = "Data Source=.\\SQLEXPRESS;Initial Catalog=SocialNetwork;Integrated Security=True;Encrypt=False";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_socialcontext);
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


            modelBuilder.Entity<PostFile>().HasKey(x => new { x.PostId, x.FileId });
            modelBuilder.Entity<PostReaction>().HasKey(x => new {  x.PostId, x.ReactionId });
            modelBuilder.Entity<CommentReaction>().HasKey(x => new { x.CommentId, x.ReactionId });
            modelBuilder.Entity<GroupChatUser>().HasKey(x => new { x.UserId, x.GroupChatId });
            modelBuilder.Entity<PrivateMessageReaction>().HasKey(x => new { x.PrivateMessageId, x.ReacitonId });
            modelBuilder.Entity<GroupChatMessageReaction>().HasKey(x => new { x.GroupChatMessageId, x.ReacitonId });
            modelBuilder.Entity<UserRelation>().HasKey(x => new { x.SenderId, x.ReceiverId });



            modelBuilder.Entity<PrivateMessage>().HasMany(x=>x.PrivateMessageReactions)
                .WithOne(x=>x.PrivateMessage).HasForeignKey(x=>x.PrivateMessageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupChatMessage>().HasMany(x => x.GroupChatMessageReactions)
                .WithOne(x => x.GroupChatMessage).HasForeignKey(x => x.GroupChatMessageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupChatMessageReaction>().HasOne(x => x.Reaction).WithMany()
                .HasForeignKey(x => x.ReacitonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrivateMessageReaction>().HasOne(x => x.Reaction).WithMany()
                .HasForeignKey(x => x.ReacitonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GroupChatUser>().Property(x => x.AddedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<UserRelation>().Property(x => x.SentAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PrivateMessageReaction>().Property(x => x.ReactedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<GroupChatMessageReaction>().Property(x => x.ReactedAt).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<CommentReaction>().Property(x => x.ReactedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PostReaction>().Property(x => x.ReactedAt).HasDefaultValueSql("GETDATE()");



            base.OnModelCreating(modelBuilder);

        }


        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostFile> PostFile { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<PostReaction> PostReaction { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentReaction> CommentReaction { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<GroupChatUser> GroupChatUsers { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<GroupChatMessage> GroupChatMessage { get; set; }
        public DbSet<PrivateMessageReaction> PrivateMessageReactions { get; set; }
        public DbSet<GroupChatMessageReaction> GroupChatMessageReactions { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

        //public DbSet<FileMedju> FileMedjus { get; set; }
    }
}
