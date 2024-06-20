using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class PostReaction
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int ReactionId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Reaction Reaction { get; set; }
        public virtual User User { get; set; }
        public DateTime ReactedAt { get; set; }
    }
}
