using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DataAccess;
using SocialNetwork.Domain;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialController : ControllerBase
    {
        // GET: api/<InitialController>
        [HttpGet]
        public IActionResult Get()
        {
            //var conn = new SocialNetworkContext();
            Role role = new Role
            {
                Name = "role 3"
            };
            //conn.Roles.Add(role);
            //conn.SaveChanges();
            return Ok();
        }

        // GET api/<InitialController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InitialController>
        [HttpPost]
        public IActionResult Post()
        {
            //var conn = new SocialNetworkContext();
            //if (conn.Users.Any())
            //{
            //    return Conflict();
            //}

            //List<Category> categories = new List<Category>()
            //{
            //    new Category{ Name = "Politics"},
            //    new Category{ Name = "Gaming", Children = new List<Category>(){ new Category { Name= "Dota"}, new Category { Name = "Counter Strike 1.6" } } },
            //    new Category {Name = "Sport", Children = new List<Category>(){ new Category { Name= "Football"} } }
            //};

            List<Category> categories = new List<Category>()
            {
                new Category{ Name = "Politics"},
                new Category{ Name = "Gaming"},
                new Category {Name = "Sport"}
            };


            List<Category> categoriesChildren = new List<Category>()
            {
               new Category{ Name = "Dota", Parent = categories.ElementAt(1)},
               new Category{ Name = "Counter Strike 1.6", Parent = categories.ElementAt(1)},
               new Category{ Name = "Football", Parent = categories.ElementAt(2)},
            };

            List<Role> roles = new List<Role>()
            {
                new Role { Name = "User"},
                new Role { Name = "Admin"}
            };

            List<Domain.File> files = new List<Domain.File>()
            {
                new Domain.File { Path = "image1.jpeg", Type = FileType.Image},
                new Domain.File { Path = "video1.mp4", Type = FileType.Video},
                new Domain.File { Path = "video2.mp4", Type = FileType.Video},
                new Domain.File { Path = "image2.jpeg", Type = FileType.Image},
                new Domain.File { Path = "image3.jpeg", Type = FileType.Image},
                new Domain.File { Path = "image4.jpeg", Type = FileType.Image},
                new Domain.File { Path = "image5.jpeg", Type = FileType.Image},
                new Domain.File { Path = "image6.jpeg", Type = FileType.Image},
                new Domain.File { Path = "like.jpeg", Type = FileType.Image},
                new Domain.File { Path = "dislike.jpeg", Type = FileType.Image},
                new Domain.File { Path = "default.jpeg", Type = FileType.Image}
            };

            List<User> users = new List<User>()
            {
                new User
                {
                    FirstName = "Emily",
                    LastName = "Johnson",
                    UserName = "emily.johnson",
                    Email = "emily.johnson@test.com",
                    Password = "user",
                    BirthDate = new DateTime(1990,10,25),
                    Role = roles.First(),
                    Image = files.ElementAt(4)
                },
                new User
                {
                    FirstName = "David",
                    LastName = "Smith",
                    UserName = "david_smith",
                    Email = "david.smith@test.com",
                    Password = "user",
                    BirthDate = new DateTime(1985,05,22),
                    Role = roles.First(),
                    Image = files.ElementAt(5)
                },
                new User
                {
                    FirstName = "Samantha",
                    LastName = "Brown",
                    UserName = "sam.brown89",
                    Email = "sam.brown89@test.com",
                    Password = "user",
                    BirthDate = new DateTime(1995,03,08),
                    Role = roles.First(),
                    Image = files.ElementAt(6)
                },
                new User
                {
                    FirstName = "Michael",
                    LastName = "Lee",
                    UserName = "mikelee_22",
                    Email = "michael22@test.com",
                    Password = "admin",
                    BirthDate = new DateTime(1988,07,30),
                    Role = roles.ElementAt(1),
                    Image = files.ElementAt(7)
                }
            };

            List<Post> posts = new List<Post>()
            {
                new Post
                {
                    Title = "Political Perspective: Sharing My Views",
                    Description = "Just shared my thoughts on the upcoming budget proposal.",
                    Author = users.ElementAt(0),
                    Category = categories.ElementAt(0)
                },
                new Post
                {
                    Title = "Nostalgia Alert: Dota 1 Throwback!",
                    Description = "Who else remembers the thrill of playing Dota 1 back in the day?",
                    Author = users.ElementAt(1),
                    Category = categoriesChildren.ElementAt(0)
                },
                new Post
                {
                    Title = "Game Day Fever: Football Fans Unite!",
                    Description = "Ready for another thrilling match day?",
                    Author = users.ElementAt(2),
                    Category = categoriesChildren.ElementAt(2)
                },
                new Post
                {
                    Title = "Goal Celebration: Victorious Moments",
                    Description = "Watch my compilation of best goal celebrations",
                    Author = users.ElementAt(2),
                    Category = categoriesChildren.ElementAt(2)
                }
            };

            List<Comment> comments = new List<Comment>()
            {
                new Comment
                {
                    Text = "Love this game!",
                    User = users.ElementAt(0),
                    Post = posts.ElementAt(1),
                    Children = new List<Comment>()
                    {
                        new Comment
                        {
                            Text = "Love it too!",
                            Post = posts.ElementAt(1),
                            User = users.ElementAt(2)
                        }
                    }
                },
                new Comment
                {
                    Text = "Interesting post",
                    User = users.ElementAt(1),
                    Post = posts.ElementAt(0)
                },
                new Comment
                {
                    Text = "Nice compilation!",
                    User = users.ElementAt(0),
                    Post = posts.ElementAt(3)
                },
                new Comment
                {
                    Text = "Nice editing skills",
                    User = users.ElementAt(1),
                    Post = posts.ElementAt(3)

                }
            };
            List<Reaction> reactions = new List<Reaction>()
            {
                new Reaction
                {
                    Name = "Like",
                    Icon = files.ElementAt(8)
                },
                new Reaction
                {
                    Name = "Dislike",
                    Icon = files.ElementAt(9)
                }
            };
            List<CommentReaction> commentReactions = new List<CommentReaction>()
            {
                new CommentReaction
                {
                    Comment = comments.ElementAt(0),
                    Reaction = reactions.ElementAt(1),
                    User = users.ElementAt(0)
                },
                new CommentReaction
                {
                    Comment = comments.ElementAt(2),
                    Reaction = reactions.ElementAt(1),
                    User = users.ElementAt(2)
                },
                new CommentReaction
                {
                    Comment = comments.ElementAt(3),
                    Reaction = reactions.ElementAt(1),
                    User = users.ElementAt(1)
                },
                new CommentReaction
                {
                    Comment = comments.ElementAt(1),
                    Reaction = reactions.ElementAt(0),
                    User = users.ElementAt(2)
                }
            };


            List<PostReaction> postReactions = new List<PostReaction>()
            {
                new PostReaction
                {
                    Post = posts.ElementAt(0),
                    Reaction = reactions.ElementAt(0),
                    User = users.ElementAt(1)
                },
                new PostReaction
                {
                    Post = posts.ElementAt(2),
                    Reaction = reactions.ElementAt(1),
                    User = users.ElementAt(0)
                },
                new PostReaction
                {
                    Post = posts.ElementAt(3),
                    Reaction = reactions.ElementAt(0),
                    User = users.ElementAt(1)
                },
                new PostReaction
                {
                    Post = posts.ElementAt(3),
                    Reaction = reactions.ElementAt(1),
                    User = users.ElementAt(2)
                }
            };


            List<PostFile> postFiles = new List<PostFile>()
            {
                new PostFile
                {
                    Post = posts.ElementAt(0),
                    File = files.ElementAt(0)
                },
                new PostFile
                {
                    Post = posts.ElementAt(1),
                    File = files.ElementAt(1)
                },
                new PostFile
                {
                    Post = posts.ElementAt(2),
                    File = files.ElementAt(3)
                },
                new PostFile
                {
                    Post = posts.ElementAt(3),
                    File = files.ElementAt(2)
                }
            };

            List<UserRelation> userRealtions = new List<UserRelation>()
            {
                new UserRelation
                {
                    Sender = users.ElementAt(0),
                    Receiver = users.ElementAt(1),
                    IsAccepted = true,
                    AcceptedDate = DateTime.UtcNow
                },
                new UserRelation
                {
                    Sender = users.ElementAt(1),
                    Receiver = users.ElementAt(2)
                },
                new UserRelation
                {
                    Sender = users.ElementAt(1),
                    Receiver = users.ElementAt(3),
                    IsAccepted = true,
                    AcceptedDate = DateTime.UtcNow
                }
            };

            List<GroupChat> groupChats = new List<GroupChat>()
            {
                new GroupChat
                {
                    Name = "Politics group"
                },
                new GroupChat
                {
                    Name = "Football talk group"
                }
            };

            List<GroupChatUser> groupChatUsers = new List<GroupChatUser>()
            {
                new GroupChatUser
                {
                    User = users.ElementAt(0),
                    GroupChat = groupChats.ElementAt(0)
                },
                new GroupChatUser
                {
                    User = users.ElementAt(1),
                    GroupChat = groupChats.ElementAt(1)
                },
                new GroupChatUser
                {
                    User = users.ElementAt(1),
                    GroupChat = groupChats.ElementAt(0)
                },
                new GroupChatUser
                {
                    User = users.ElementAt(2),
                    GroupChat = groupChats.ElementAt(1)
                }
            };
            List<PrivateMessage> privateMessages = new List<PrivateMessage>()
            {
                new PrivateMessage
                {
                    Text = "Hey, how are you?",
                    Sender = users.ElementAt(0),
                    Receiver = users.ElementAt(1),
                    ReceviedAt = DateTime.Now,
                    SeenAt = DateTime.Now.AddDays(2)
                },
                new PrivateMessage
                {
                    Text = "Good, what about you?",
                    Sender = users.ElementAt(1),
                    Receiver = users.ElementAt(0),
                    ReceviedAt = DateTime.Now
                },
                new PrivateMessage
                {
                    Text = "How was the exam?",
                    Sender = users.ElementAt(3),
                    Receiver = users.ElementAt(2),
                    ReceviedAt = DateTime.Now,
                    SeenAt = DateTime.Now.AddHours(3)
                },
                new PrivateMessage
                {
                    Text = "It was easy",
                    Sender = users.ElementAt(2),
                    Receiver = users.ElementAt(3),
                    ReceviedAt = DateTime.Now
                }
            };

            List<GroupChatMessage> groupChatMessages = new List<GroupChatMessage>()
            {
                new GroupChatMessage
                {
                    GroupChat = groupChats.ElementAt(0),
                    Sender = users.ElementAt(0),
                    Text = "This is a very good topic.",
                    ReceviedAt = DateTime.Now
                },
                new GroupChatMessage
                {
                    GroupChat = groupChats.ElementAt(0),
                    Sender = users.ElementAt(1),
                    Text = "It really is.",
                    ReceviedAt = DateTime.Now
                },
                new GroupChatMessage
                {
                    GroupChat = groupChats.ElementAt(1),
                    Sender = users.ElementAt(2),
                    Text = "Nice game.",
                    ReceviedAt = DateTime.Now
                }
            };

            List<GroupChatMessageReaction> groupChatMessageReactions = new List<GroupChatMessageReaction>()
            {
                new GroupChatMessageReaction
                {
                    User = users.ElementAt(0),
                    GroupChatMessage = groupChatMessages.ElementAt(1),
                    Reaction = reactions.ElementAt(0)
                },
                new GroupChatMessageReaction
                {
                    User = users.ElementAt(1),
                    GroupChatMessage = groupChatMessages.ElementAt(2),
                    Reaction = reactions.ElementAt(1)
                }
            };


            List<PrivateMessageReaction> privateMessageReactions = new List<PrivateMessageReaction>()
            {
                new PrivateMessageReaction
                {
                    User = users.ElementAt(1),
                    PrivateMessage = privateMessages.ElementAt(0),
                    Reaction = reactions.ElementAt(0)
                },
                new PrivateMessageReaction
                {
                    User = users.ElementAt(3),
                    PrivateMessage = privateMessages.ElementAt(2),
                    Reaction = reactions.ElementAt(1)
                }
            };

            //conn.Categories.AddRange(categories);
            //conn.Categories.AddRange(categoriesChildren);
            //conn.Roles.AddRange(roles);
            //conn.Files.AddRange(files);
            //conn.Users.AddRange(users);
            //conn.Posts.AddRange(posts);
            //conn.Comment.AddRange(comments);
            //conn.Reactions.AddRange(reactions);
            //conn.CommentReaction.AddRange(commentReactions);
            //conn.PostReaction.AddRange(postReactions);
            //conn.PostReaction.AddRange(postReactions);
            //conn.PostFile.AddRange(postFiles);
            //conn.UserRelations.AddRange(userRealtions);
            //conn.GroupChats.AddRange(groupChats);
            //conn.GroupChatUsers.AddRange(groupChatUsers);
            //conn.PrivateMessages.AddRange(privateMessages);
            //conn.GroupChatMessage.AddRange(groupChatMessages);
            //conn.GroupChatMessageReactions.AddRange(groupChatMessageReactions);
            //conn.PrivateMessageReactions.AddRange(privateMessageReactions);

            //conn.SaveChanges();
            return Created();
        }

        // PUT api/<InitialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InitialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
