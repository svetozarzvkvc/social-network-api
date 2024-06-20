using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Children { get; set; } = new List<Comment>();
        public virtual ICollection<CommentReaction> Reactions { get; set; } = new List<CommentReaction>();
    }
}
