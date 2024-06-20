﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.DataAccess;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    [Migration("20240616175309_AddedErrorLogTable")]
    partial class AddedErrorLogTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialNetwork.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SocialNetwork.Domain.CommentReaction", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReactedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId", "ReactionId");

                    b.HasIndex("ReactionId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentReaction");
                });

            modelBuilder.Entity("SocialNetwork.Domain.ErrorLog", b =>
                {
                    b.Property<Guid>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrackTrace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrorId");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("SocialNetwork.Domain.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("GroupChats");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("GroupChatId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("ReceviedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("GroupChatMessage");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatMessageReaction", b =>
                {
                    b.Property<int>("GroupChatMessageId")
                        .HasColumnType("int");

                    b.Property<int>("ReacitonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReactedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GroupChatMessageId", "ReacitonId");

                    b.HasIndex("ReacitonId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupChatMessageReactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GroupChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("UserId", "GroupChatId");

                    b.HasIndex("GroupChatId");

                    b.ToTable("GroupChatUsers");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Title");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PostFile", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("PostFile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PostReaction", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReactedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "ReactionId");

                    b.HasIndex("ReactionId");

                    b.HasIndex("UserId");

                    b.ToTable("PostReaction");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PrivateMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceviedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SeenAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("PrivateMessages");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PrivateMessageReaction", b =>
                {
                    b.Property<int>("PrivateMessageId")
                        .HasColumnType("int");

                    b.Property<int>("ReacitonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReactedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PrivateMessageId", "ReacitonId");

                    b.HasIndex("ReacitonId");

                    b.HasIndex("UserId");

                    b.ToTable("PrivateMessageReactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SocialNetwork.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ImageId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("FirstName", "LastName", "UserName", "Email");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("FirstName", "LastName", "UserName", "Email"), new[] { "BirthDate" });

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.Domain.UserRelation", b =>
                {
                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AcceptedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SentAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("UserRelations");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Category", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Comment", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Domain.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.CommentReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Comment", "Comment")
                        .WithMany("Reactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "User")
                        .WithMany("CommentReactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatMessage", b =>
                {
                    b.HasOne("SocialNetwork.Domain.GroupChat", "GroupChat")
                        .WithMany("GroupChatMessages")
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "Sender")
                        .WithMany("SentGroupChatMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatMessageReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.GroupChatMessage", "GroupChatMessage")
                        .WithMany("GroupChatMessageReactions")
                        .HasForeignKey("GroupChatMessageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReacitonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "User")
                        .WithMany("GroupChatMessageReaction")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GroupChatMessage");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatUser", b =>
                {
                    b.HasOne("SocialNetwork.Domain.GroupChat", "GroupChat")
                        .WithMany("GroupChatUsers")
                        .HasForeignKey("GroupChatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "User")
                        .WithMany("GroupChatUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GroupChat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Post", b =>
                {
                    b.HasOne("SocialNetwork.Domain.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PostFile", b =>
                {
                    b.HasOne("SocialNetwork.Domain.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Post", "Post")
                        .WithMany("PostFiles")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PostReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "User")
                        .WithMany("PostReactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PrivateMessage", b =>
                {
                    b.HasOne("SocialNetwork.Domain.User", "Receiver")
                        .WithMany("ReceivedPrivateMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "Sender")
                        .WithMany("SentPrivateMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PrivateMessageReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.PrivateMessage", "PrivateMessage")
                        .WithMany("PrivateMessageReactions")
                        .HasForeignKey("PrivateMessageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Reaction", "Reaction")
                        .WithMany()
                        .HasForeignKey("ReacitonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "User")
                        .WithMany("PrivateMessageReactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PrivateMessage");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Reaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.File", "Icon")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Icon");
                });

            modelBuilder.Entity("SocialNetwork.Domain.User", b =>
                {
                    b.HasOne("SocialNetwork.Domain.File", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SocialNetwork.Domain.UserRelation", b =>
                {
                    b.HasOne("SocialNetwork.Domain.User", "Receiver")
                        .WithMany("ReceivedRequests")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.User", "Sender")
                        .WithMany("SentRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Comment", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChat", b =>
                {
                    b.Navigation("GroupChatMessages");

                    b.Navigation("GroupChatUsers");
                });

            modelBuilder.Entity("SocialNetwork.Domain.GroupChatMessage", b =>
                {
                    b.Navigation("GroupChatMessageReactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostFiles");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.PrivateMessage", b =>
                {
                    b.Navigation("PrivateMessageReactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SocialNetwork.Domain.User", b =>
                {
                    b.Navigation("CommentReactions");

                    b.Navigation("Comments");

                    b.Navigation("GroupChatMessageReaction");

                    b.Navigation("GroupChatUsers");

                    b.Navigation("PostReactions");

                    b.Navigation("Posts");

                    b.Navigation("PrivateMessageReactions");

                    b.Navigation("ReceivedPrivateMessages");

                    b.Navigation("ReceivedRequests");

                    b.Navigation("SentGroupChatMessages");

                    b.Navigation("SentPrivateMessages");

                    b.Navigation("SentRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
