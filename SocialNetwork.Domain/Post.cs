 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<PostFile> PostFiles { get; set; } = new List<PostFile>();
        public virtual ICollection<PostReaction> Reactions { get; set; } = new List<PostReaction>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
