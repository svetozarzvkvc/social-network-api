using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public abstract class Message : Entity
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public DateTime ReceviedAt { get; set; }
        public virtual User Sender { get; set; }
    }

    public class PrivateMessage : Message
    {
        public DateTime? SeenAt { get; set; }
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
        public virtual ICollection<PrivateMessageReaction> PrivateMessageReactions { get; set; } = new List<PrivateMessageReaction>();

    }

    public class GroupChatMessage : Message
    {
        public int GroupChatId { get; set;}
        public virtual GroupChat GroupChat { get; set; }
        public virtual ICollection<GroupChatMessageReaction> GroupChatMessageReactions { get; set; } = new List<GroupChatMessageReaction>();

    }
}
