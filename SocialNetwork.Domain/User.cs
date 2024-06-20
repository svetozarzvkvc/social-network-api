using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
        public int ImageId { get; set; }
        public virtual Role Role { get; set; }
        public virtual File Image { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>(); //Y
        public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>(); //Y
        public virtual ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();
        public virtual ICollection<GroupChatUser> GroupChatUsers { get; set; } = new List<GroupChatUser>(); //Y
        public virtual ICollection<PrivateMessage> ReceivedPrivateMessages { get; set; } = new List<PrivateMessage>(); //Y
        public virtual ICollection<PrivateMessage> SentPrivateMessages { get; set; } = new List<PrivateMessage>(); //Y
        public virtual ICollection<GroupChatMessage> SentGroupChatMessages { get; set; } = new List<GroupChatMessage>();
        public virtual ICollection<PrivateMessageReaction> PrivateMessageReactions { get; set; } = new List<PrivateMessageReaction>();
        public virtual ICollection<GroupChatMessageReaction> GroupChatMessageReaction { get; set; } = new List<GroupChatMessageReaction>();
        public virtual ICollection<UserRelation> SentRequests { get; set; } = new List<UserRelation>(); //Y
        public virtual ICollection<UserRelation> ReceivedRequests { get; set; } = new List<UserRelation>(); //Y




    }
}
