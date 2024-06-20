using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public abstract class MessageReaction
    {
       // public int MessageId { get; set; }
        public int UserId { get; set; }
        public int ReacitonId { get; set; }
        public DateTime ReactedAt { get; set; }
        //public virtual Message Message { get; set; }
        public virtual User User { get; set; }
        public virtual Reaction Reaction { get; set; }
    }

    public class PrivateMessageReaction : MessageReaction
    {
        public int PrivateMessageId { get; set; }

        public virtual PrivateMessage PrivateMessage { get; set; }

    }

    public class GroupChatMessageReaction : MessageReaction
    {
        public int GroupChatMessageId { get; set; }
        public virtual GroupChatMessage GroupChatMessage { get; set; }
    }
}
